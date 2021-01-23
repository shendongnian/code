    public static void Main(string[] args)
    {
        var imagePath = Assembly.GetEntryAssembly().CodeBase;
        var commandLine = string.Join(" ", args.Select(s => s.Contains(' ') ? "\"" + s + "\"" : s));
        var newProcess = Process.Start(imagePath, commandLine);
    }
