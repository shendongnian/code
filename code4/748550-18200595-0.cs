    string AlaaJoseph = "October 23, 1996";
    DateTime AlaaJosephDateTime;
    if (DateTime.TryParseExact(AlaaJoseph, "MMMM dd, yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out AlaaJosephDateTime))
        Console.WriteLine("DateTimeTryParseExact Passed");
    string JennetteMcCurdy = "June 26, 1992";
    DateTime JennetteMcCurdyDateTime;
    if (DateTime.TryParseExact(JennetteMcCurdy, "MMMM dd, yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out JennetteMcCurdyDateTime))
        Console.WriteLine("DateTimeTryParseExact Passed");
