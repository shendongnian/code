    static void Main(string[] args)
            {
    
                InitialSessionState initial = InitialSessionState.CreateDefault();
                initial.ImportPSModule(new string[] {"C:\\Program Files\\Common Files\\Microsoft Lync Server 2010\\Modules\\Lync\\Lync.psd1"} );
                Runspace runspace = RunspaceFactory.CreateRunspace(initial);
                runspace.Open();     
                PowerShell ps = PowerShell.Create();
                ps.Runspace = runspace;
                ps.Commands.AddCommand("Get-csuser");
                foreach (PSObject result in ps.Invoke())
                {
                    Console.WriteLine(result.Members["Identity"].Value);
                }
    
                Console.ReadLine();
    
            }
