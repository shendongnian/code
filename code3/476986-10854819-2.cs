    public static void Main(string[] args)
    {
        var commandLine = string.Join(" ", args.Select(s => s.Contains(' ') ? "\"" + s + "\"" : s));
        var newProcess = Process.Start(Environment.GetCommandLineArgs()[0], commandLine);
    }
