        static void Main(string[] args)
        {
            Options options = new Options();
            var parser = new CommandLine.Parser();
            if (parser.ParseArgumentsStrict(args, options, () => Environment.Exit(-2)))
            {
                Run(options);
            }
        }
    private static void Run(Options options)
    {
        String mainArguments = options.MainArguments;
        // Do whatever you want with your main arguments.
        
        Process targetProcess = Process.Start(options.TargetApplication, options.TargetParameters);
    }
