    // Note: changed method and parameter names to be nicer
    private static void Print(StreamWriter writer, string log, bool screen = false)
    {
        // Note: logs should almost always use UTC rather than the system local
        // time zone
        DateTime now = DateTime.UtcNow;
     
        // TODO: Determine what format you want to write your timestamps in.
        sw.WriteLine(CultureInfo.InvariantCulture,
                     "{0:yyyy-MM-dd'T'HH:mm:ss.fff}: {1}", now, log);
        if (screen)
        {
            Console.WriteLine(mlog);
        }
    }
