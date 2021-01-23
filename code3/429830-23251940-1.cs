    // the shortcut function wl, kind of write line
    public void wl( string format, params object[] parms){
        Console.WriteLine(format, parms);
    }
    // examples:
    ws("String with no formatting parameters");
    wl("String without formatting parameters");
    wl("String with {0} parameters {1}", 2, "included");
    wl("several parameters {0} {1} {2} repeated {0}", 1234, 5678, 6543);
