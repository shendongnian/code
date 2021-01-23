    {
        var analyzer = new Analyzer();
        try
        {
            analyzer.Analyze();
        }
        catch (FatalException)
        {
            Console.WriteLine("Analysis failed");
        }
    }
