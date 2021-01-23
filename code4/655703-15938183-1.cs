     public bool checkSignature(string path)
        {
            RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
            Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
            runspace.Open();
            RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(String.Format("Get-AuthenticodeSignature \"{0}\"", path));
            Collection<PSObject> results = pipeline.Invoke();
            Signature check = (Signature)results[0].BaseObject;
            if (check.Status == SignatureStatus.Valid)
            {
                return true;
            }
            return false;
        }
