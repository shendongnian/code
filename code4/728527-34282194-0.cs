            InitialSessionState iss = InitialSessionState.CreateDefault();
            iss.ImportPSModule(new String[] { @"<Module name or module path>" });
            
			using (Runspace runspace = RunspaceFactory.CreateRunspace(iss))
			{
            }
