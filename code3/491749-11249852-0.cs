    static DateTime ParseExactYear(string input)
    {
        if (input.Length == 7) input = "000" + input; // years 1 to 9 as well.
        if (input.Length == 8) input = "00" + input;
        if (input.Length == 9) input = "0" + input;
        return DateTime.ParseExact(input, "yyyy.M.d", null);
    }
    Debug.WriteLine(ParseExactYear("1000.12.31"));
    Debug.WriteLine(ParseExactYear("999.12.31"));
    Debug.WriteLine(ParseExactYear("99.12.31"));
    Debug.WriteLine(ParseExactYear("9.12.31"));
    Output:
    12/31/1000 12:00:00 AM
    12/31/0999 12:00:00 AM
    12/31/0099 12:00:00 AM
    12/31/0009 12:00:00 AM
