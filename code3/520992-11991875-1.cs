    using System;
    using System.Management;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                new Test().Run();
                Console.ReadLine();
            }
        }
        internal class Test
        {
            public void Run()
            {
                ProcessWatcher procWatcher = new ProcessWatcher();
                procWatcher.Start();
            }
            private class ProcessWatcher : ManagementEventWatcher
            {
                private const string wql = 
                       @"SELECT * FROM __InstanceCreationEvent WITHIN 1
                         WHERE TargetInstance ISA 'Win32_Process'";
                public ProcessWatcher()
                {
                    this.Query.QueryLanguage = "WQL";
                    this.Query.QueryString = wql;
                    this.EventArrived += newProcessStarted;
                }
                private void newProcessStarted(object sender, 
                                               EventArrivedEventArgs e)
                {
                    var process = e.NewEvent["TargetInstance"] 
                                  as ManagementBaseObject;
                    if (process != null)
                    {
                        var cmdLine = process.Properties["CommandLine"].Value;
                        Console.WriteLine(cmdLine);
                    }
                }
            }
        }
    }
