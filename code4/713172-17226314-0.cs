    using System.ServiceProcess;
    using System.Diagnostics;
    using System;
    
    namespace MyApplicationNamespace
    {
        static class Program
        {
            static void Main(string[] args)
            {
                if (args != null && args.Length > 0)
                {    
                    switch (args[0])
                    {
                        case "-debug":
                        case "-d":
                            StartConsole();
                            break;
    
                        default:
                            break;
                    }
                }
                else
                {
                    StartService();
                }    
            }
    
            private static void StartConsole()
            {
                MyApp myApp = new MyApp();
                myApp.StartProcessing();
                Console.ReadLine();
            }
    
            private static void StartService()
            {
                ServiceBase[] ServicesToRun;   
                ServicesToRun = new ServiceBase[] { new MyApp() };
                ServiceBase.Run(ServicesToRun);
            }               
        }
    }
