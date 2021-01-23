    string s = "8:40 PM"; // or from your login box
    DateTime time;
    string[] formats = {"h:mm tt", "hh:mm tt", "H:mm", "HH:mm"};
    if (DateTime.TryParseExact(s, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out time))
    {
        int HRS = time.Hour;
        int MINS = time.Minute;
        Console.WriteLine("HRS = " + HRS.ToString());
        Console.WriteLine("MINS = " + MINS.ToString());
    }
    else
    {
        Console.WriteLine("Invalid time format!");
    }
