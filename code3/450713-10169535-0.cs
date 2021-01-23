    InitialSessionState iss = InitialSessionState.CreateDefault();
    iss.ImportPSModule(new string[] { "MSOnline" });
    
    using (Runspace runspace = RunspaceFactory.CreateRunspace(iss))
    {
    // blah
    }
