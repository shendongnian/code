    DateTime d = DateTime.Now;
    var format = "yyyy-MM-dd HH:mm:ss,fff";
    var fileDates = System.IO.File.ReadAllLines(path)
                    .Where(l => l.Length >= format.Length
                            && DateTime.TryParseExact(l.Substring(0, format.Length)
                                                    , format
                                                    , CultureInfo.InvariantCulture
                                                    , DateTimeStyles.None
                                                    , out d)
                    ).Select(l => d);
    if (fileDates.Any())
    {
        DateTime firstDate = fileDates.First();  // 2011-11-17 23:05:17,266
        DateTime lastDate  = fileDates.Last();   // 2011-11-17 23:17:08,862
    }
