    public bool WriteToConsole(string format, params object[] args)
    {           
        var succeeded = false;
        var argRegex = new Regex(@"\{\d+\}");
        if ((args != null) && (argRegex.Matches(format).Count == args.Length))
        {
            Console.WriteLine(format, args);
            succeeded = true;
        }
        else
        {
            Console.WriteLine(format);
        }
        return succeeded;
    }
