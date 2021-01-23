    var inputDay = "Saturday";
    var SourceCulture = new System.Globalization.CultureInfo("en-gb");
    var DestinationCulture = new System.Globalization.CultureInfo("pl-pl");
    var dayInt = Array.IndexOf(SourceCulture.DateTimeFormat.DayNames, inputDay);
    Console.WriteLine(DestinationCulture.DateTimeFormat.GetDayName((DayOfWeek)dayInt));
