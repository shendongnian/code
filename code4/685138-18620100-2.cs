        internal sealed class Options
        {
            [Option('a', "mainArguments", Required=true, HelpText="The arguments for the main application")]
            public String MainArguments { get; set; }
            
            [Option('t', "targetApplication", Required = true, HelpText = "The second application to run.")]
            public String TargetApplication { get; set; }
            [Option('p', "targetParameters", Required = true, HelpText = "The arguments to pass to the target application.")]
            public String targetParameters { get; set; }
            [ParserState]
            public IParserState LastParserState { get; set; }
            [HelpOption]
            public string GetUsage()
            {
                return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
            }
        }
