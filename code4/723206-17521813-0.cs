    var input = "blah 1 2 3 7-Jul-13 6:15:00 4 5 6 blah";
    var pattern = "d-MMM-yy H:mm:ss";
    for (int i = 0; i < input.Length - pattern.Length; i++)
    {
        var result = NodaTime.Text
            .LocalDateTimePattern
            .Create(pattern, System.Globalization.CultureInfo.CurrentUICulture)
            .Parse(input.Substring(i, pattern.Length));
        if (result.Success)
        {
            Console.WriteLine(result.Value);
            break;
        }
    }
