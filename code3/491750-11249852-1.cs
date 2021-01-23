    static DateTime ParseExactYear(string input)
    {
        switch (input.IndexOf('.'))
        {
            case 1: input = "000" + input; break;
            case 2: input = "00" + input; break;
            case 3: input = "0" + input; break;
        }
        return DateTime.ParseExact(input, "yyyy.M.d", null);
    }
    Debug.WriteLine(ParseExactYear("1000.12.31"));
    Debug.WriteLine(ParseExactYear("999.12.31"));
    Debug.WriteLine(ParseExactYear("99.12.31"));
    Debug.WriteLine(ParseExactYear("9.12.31"));
    Debug.WriteLine(ParseExactYear("1000.1.1"));
    Debug.WriteLine(ParseExactYear("999.1.1"));
    Debug.WriteLine(ParseExactYear("99.1.1"));
    Debug.WriteLine(ParseExactYear("9.1.1"));
    Output:
    12/31/1000 12:00:00 AM
    12/31/0999 12:00:00 AM
    12/31/0099 12:00:00 AM
    12/31/0009 12:00:00 AM
    1/1/1000 12:00:00 AM
    1/1/0999 12:00:00 AM
    1/1/0099 12:00:00 AM
    1/1/0009 12:00:00 AM
