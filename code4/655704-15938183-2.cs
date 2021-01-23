     public bool checkSignature(string path)
        {
            
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(String.Format("Get-AuthenticodeSignature \"{0}\"", path));
            Collection<PSObject> results = pipeline.Invoke();
            Signature check = (Signature)results[0].BaseObject;
            runspace.Close();
            if (check.Status == SignatureStatus.Valid)
            {
                return true;
            }
            return false;
        }
