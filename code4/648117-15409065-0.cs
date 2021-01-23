    using (var sr = new StreamReader(Server.MapPath("03122013114450.txt"), true))
    {
        var flipper = true;
        var line = sr.ReadLine();
        while (line != null)
        {
            if (flipper)
            {
                // Do somthing with this line
            }
            flipper = !flipper
            line = sr.ReadLine();
        }
    }
