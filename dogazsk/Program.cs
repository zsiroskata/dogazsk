using dogazsk.src;
using System.Globalization;
using System.Text;

List<Nagyvaros> nagyvarosok = new();
using StreamReader sr = new StreamReader(
    path:@"..\..\..\src\varosok.csv",
    encoding: Encoding.UTF8);

sr.ReadLine();
while (!sr.EndOfStream)
{
    nagyvarosok.Add(new Nagyvaros(sr.ReadLine()));
}

sr.Close();



Console.WriteLine($"A kollekció hossza: {nagyvarosok.Count}");

//1) hány millió fő él összesen kínai nagyvárosokban?
Console.WriteLine("1.feladat");
var kinaiOsszesNepesseg = nagyvarosok.Where(x => x.Orszag == "Kína").Sum(x => x.Nepesseg);
Console.WriteLine($"Összes kínai nagyváros népessége: {kinaiOsszesNepesseg:F2} millió fő");

//2) mekkora az indiai nagyvárosok átlaglélekszáma?
Console.WriteLine("\n2.feladat");
var indiaiAtlag = nagyvarosok.Where(x => x.Orszag == "India").Average(x => x.Nepesseg);
Console.WriteLine($"Indiai nagyvárosok átlaglélekszáma: {indiaiAtlag:F2} millió fő");

// 3) melyik nagyváros a legnépesebb?
Console.WriteLine("\n3.feladat");
Nagyvaros legnepesebb = nagyvarosok.OrderByDescending(x => x.Nepesseg).First();
Console.WriteLine($"Legnépesebb nagyváros: {legnepesebb}");

// 4) 20M lakos feletti nagyvárosok, népesség szerint csökkenő sorrendben.
Console.WriteLine("\n4.feladat");
var huszMFelett = nagyvarosok.Where(x => x.Nepesseg > 20).OrderByDescending(x => x.Nepesseg);
Console.WriteLine("20M lakos feletti nagyvárosok, csökkenő sorrendben:");

foreach (var varos in huszMFelett)
{
    Console.WriteLine($"\t{varos}");
}

// 5) hány olyan ország van, ami több nagyávárossal is szerepel a listában?
Console.WriteLine("\n5.feladat");
var tobbVarosos = nagyvarosok.GroupBy(x => x.Orszag).Count(x => x.Count() > 1);
Console.WriteLine($"Országok száma, amelyek több nagyvárossal szerepelnek: {tobbVarosos}");

// 6) milyen betűvel kezdődik a legtöbb nagyváros neve?
Console.WriteLine("\n6.feladat");
var leggyakoribbBetu = nagyvarosok.GroupBy(x => x.Nev[0]).OrderByDescending(x => x.Count()).First().Key;
Console.WriteLine($"A legtöbb nagyváros neve  \"{leggyakoribbBetu}\" betűvel kezdődik");