    using System;
    using System.Collections.ObjectModel;
    using System.Management.Automation;
    
    namespace PowerShellRunspaceErrors
    {
        class Program
        {
            private static PowerShell s_ps;
    
            static void Main(string[] args)
            {
                s_ps = PowerShell.Create();
                ExecuteScript(@"Get-ChildItem c:\xyzzy");
                ExecuteScript("throw 'Oops, I did it again.'");
            }
    
            static void ExecuteScript(string script)
            {
                try
                {
                    s_ps.AddScript(script);
                    Collection<PSObject> results = s_ps.Invoke();
                    Console.WriteLine("Output:");
                    foreach (var psObject in results)
                    {
                        Console.WriteLine(psObject);
                    }
                    Console.WriteLine("Non-terminating errors:");
                    foreach (ErrorRecord err in s_ps.Streams.Error)
                    {
                        Console.WriteLine(err.ToString());
                    }
                }
                catch (RuntimeException ex)
                {
                    Console.WriteLine("Terminating error:");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
