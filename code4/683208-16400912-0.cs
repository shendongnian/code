    // create Powershell runspace
    Runspace runspace = RunspaceFactory.CreateRunspace();
    // open it
    runspace.Open();
    Pipeline pipeline = runspace.CreatePipeline();
    pipeline.Commands.AddScript(String.Format("$user = \"{0}\"", userName));
    pipeline.Commands.AddScript("#your main script");
    // execute the script
    Collection<psobject> results = pipeline.Invoke();
    // close the runspace
    runspace.Close();
