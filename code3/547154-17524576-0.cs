    // we start from a non-read-only invariant culture
    Thread.CurrentThread.CurrentCulture = new CultureInfo("");
    // change time separator of DateTime format info of the culture
    CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator = "<-->";
    var dt = new DateTime(2013, 7, 8, 13, 14, 15);
    Console.WriteLine(dt);  // writes "07/08/2013 13<-->14<-->15"
    var ts = new TimeSpan(13, 14, 15);
    Console.WriteLine(ts);  // writes "13:14:15"
