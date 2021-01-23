    private static void Test()
    {
        dynamic parameters = new ExpandoObject();
        parameters.test= "myImage";
        parameters.arg2= 2;
        var results = RunPowerShellFunction("My-Function", parameters);
        var obj = results[0];
        var str = results[1];
    }
    private static dynamic RunPowerShellFunction(string functionName, dynamic parameters)
    {
        dynamic rv = null;
        try
        {
            InitialSessionState iss = InitialSessionState.CreateDefault();
            using (Runspace runspace = RunspaceFactory.CreateRunspace(iss))
            {
                runspace.Name = typeof(DockerManager).Name;
                runspace.Open();
                RunspaceInvoke runSpaceInvoker = new RunspaceInvoke(runspace);
                runSpaceInvoker.Invoke("Set-ExecutionPolicy Unrestricted");
                using (var mainPowerShell = System.Management.Automation.PowerShell.Create())
                {
                    mainPowerShell.Runspace = runspace;
                    mainPowerShell.AddScript(LoadedScriptText, false);
                    mainPowerShell.Invoke();
                    var cmd = mainPowerShell.AddCommand(functionName);
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            cmd.AddParameter(parameter.Key, parameter.Value);
                        }
                    }
                    rv = cmd.Invoke();
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return rv;
    }
