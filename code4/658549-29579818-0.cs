    static void Main(string[] args)
    {
        const string date = "2015-04-11T12:45:59";
        const string format = "yyyy-MM-ddTHH:mm:ss";
        var reference = FrameworkParse(date, format);
        var method1 = JamesBarrettParse(date, format);
        
        if (reference != method1)
        {
            throw new Exception(string.Format("reference date {0} does not match SO date {1}",reference.ToString("s"),method1.ToString("s")));
        }
        const int iterations = 1000000;
        var sw = new Stopwatch();
		
        //FRAMEWORK PARSE
        Console.Write("Starting framework parse for {0} iterations...", iterations);
        sw.Start();
        DateTime dt;
        for (var i = 0; i < iterations; i++)
        {
            dt = FrameworkParse(date, format);
            if (dt.Minute != 45)
            {
                Console.WriteLine("duh");
            }
        }
        sw.Stop();
        Console.WriteLine("DONE in {0} millis",sw.ElapsedMilliseconds.ToString("F2",CultureInfo.InvariantCulture));
        //James Barrett parse
        Console.Write("Starting JB parse for {0} iterations...", iterations);
        sw.Restart();
        for (var i = 0; i < iterations; i++)
        {
            dt = JamesBarrettParse(date, format);
            if (dt.Minute != 45)
            {
                Console.WriteLine("duh");
            }
        }
        sw.Stop();
        Console.WriteLine("DONE in {0} millis",sw.ElapsedMilliseconds.ToString("F2",CultureInfo.InvariantCulture));
        Console.Write("press any key to exit");
        Console.ReadKey();
    }
    private static DateTime FrameworkParse(string s, string format, CultureInfo info = null)
    {
        var time = DateTime.ParseExact(s, format,
            info ?? CultureInfo.InvariantCulture,
            DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
        return time;
    }
