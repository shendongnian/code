    RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
    using (var runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration))
    {
        runspace.Open();
        String scriptfile = @"..\..\..\test.ps1";
        String path = @"C:\Users\Public\";
        var pipeline = runspace.CreatePipeline();
        pipeline.Commands.Add(new Command("Set-ExecutionPolicy RemoteSigned -Scope Process", true));
        pipeline.Invoke();
        pipeline = runspace.CreatePipeline();
        var myCommand = new Command(scriptfile, false);
        var testParam = new CommandParameter("username", path);
        myCommand.Parameters.Add(testParam);
        pipeline.Commands.Add(myCommand);
        var psObjects = pipeline.Invoke();
        foreach (var obj in psObjects)
        {
            Console.WriteLine(obj.ToString());
        }
        runspace.Close();
    }
    Console.WriteLine("Press a key to continue...");
    Console.ReadKey(true);
