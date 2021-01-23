    public static Collection<PSObject> GetPSResults(string powerShell,  PSCredential credential, bool throwErrors = true)
    {
        Collection<PSObject> toReturn = new Collection<PSObject>();
        WSManConnectionInfo connectionInfo = new WSManConnectionInfo() { Credential = credential };
        using (Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo))
        {
            runspace.Open();
            using (PowerShell ps = PowerShell.Create())
            {
                ps.Runspace = runspace;
                ps.AddScript(powerShell);
                toReturn = ps.Invoke();
                if (throwErrors)
                {
                    if (ps.HadErrors)
                    {
                        throw ps.Streams.Error.ElementAt(0).Exception;
                    }
                }
            }
            runspace.Close();
        }
        return toReturn;
    }
