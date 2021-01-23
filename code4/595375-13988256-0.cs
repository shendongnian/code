    DateTime d;
    var format1 = "dd/MM/yyyy";
    Regex r = new Regex("[0-3][0-9]/[0-1][0-9]/[0-9]{4}");
    var linesWithDates = System.IO.File.ReadAllLines(z)
        .Where(l => r.Matches(l).Cast<Match>()
             .Any(DateTime.TryParseExact(m.Value, format1, ...)));
