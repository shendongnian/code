    string dtObjFormat = "dd MMM yyyy HH:mm";
    string mydatetimemash = e.Date + " " + e.Time; // this becomes 25 May 2013 10:30
    DateTime dt;
    
    if (DateTime.TryParseExact(mydatetimemash, dtObjFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
    {
        Console.WriteLine(dt);
    } else 
    {
        dt = DateTime.Now;
        Console.WriteLine(dt);
    }
