    private string RunScript(string scriptText)
    {
    // create a Powershell runspace then open it
    
    Runspace runspace = RunspaceFactory.CreateRunspace();
    runspace.Open();
    
    // create a pipeline and add it to the text of the script
    
    Pipeline pipeline = runspace.CreatePipeline();
    pipeline.Commands.AddScript(scriptText);
    
    // format the output into a readable string, rather than using Get-Process
    // and returning the system.diagnostic.process
    
    pipeline.Commands.Add("Out-String");
    
    // execute the script and close the runspace
    
    Collection<psobject /> results = pipeline.Invoke();
    runspace.Close();
    
    // convert the script result into a single string
    
    StringBuilder stringBuilder = new StringBuilder();
    foreach (PSObject obj in results)
    {
    stringBuilder.AppendLine(obj.ToString());
    }
    
    return stringBuilder.ToString();
    }
