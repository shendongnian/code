    // use a string formatter to pull it all together
    string s = string.Format("{0} {1}:{2} {3}",
                             VehicleBookingDate.Text,
                             tsTimeFrom.Hour,
                             tsTimeFrom.Minute,
                             tsTimeFrom.AmPm);
    // You can parse it this way, which will assume the current culture settings
    DateTime Time_From = DateTime.Parse(s);
    // Or you can be much more specific - which you probably should do.
    DateTime Time_From = DateTime.ParseExact(s,
                                             "d/M/yyyy hh:mm:ss tt",
                                             CultureInfo.InvariantCulture);
