    if (new CommandLineParser(new CommandLineParserSettings {
                                MutuallyExclusive = true,
                                CaseSensitive = true,
                                HelpWriter = Console.Error}).ParseArguments(args, opts) {
      // consume values here
      Console.WriteLine(opts.OptionA);
    }
