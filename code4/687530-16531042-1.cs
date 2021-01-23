    // you said you were starting with a string
    string s = "1368352924.281610000";
    // but you are going to need it as a double.
    // (If it's already a double, skip these two steps)
    var d = double.Parse(s);
    // starting at the unix epoch
    DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    // simply add the number of seconds that you have
    DateTime dt = epoch.AddSeconds(d);
    Debug.WriteLine("{0} {1}", dt, dt.Kind);  // prints  05/12/2013 10:02:04 Utc
