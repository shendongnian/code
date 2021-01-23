    ps.AddCommand("Import-Module").AddArgument("CheeseDirectory");
    ps.Commands.Commands[0].MergeMyResults(PipelineResultTypes.Error, PipelineResultTypes.Output);
    var importResult = ps.Invoke();
    foreach (PSObject result in importResult)
    {
        Console.WriteLine(result);
    }
