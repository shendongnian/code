    var allMatches = 
         System.IO.File.ReadLines(path)
        .Select(l => System.Text.RegularExpressions.Regex.Match(l, @"\d{16}"))
        .Where(m => m.Success)
        .ToList();
    foreach (var match in allMatches)
    {
        String number = match.Value;
    }
