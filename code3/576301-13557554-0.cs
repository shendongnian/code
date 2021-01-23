    namespace ConsoleApplication1
    {
        using System;
        using System.Threading.Tasks;
        using AppDomainToolkit;
        class Program
        {
            static void Main(string[] args)
            {
                using (var context1 = AppDomainContext.Create())
                using (var context2 = AppDomainContext.Create())
                {
                    var task1 = Task.Factory.StartNew(
                        () =>
                        {
                            RemoteAction.Invoke(
                                context1.Domain, 
                                () => 
                                {
                                    var appName = AppDomain.CurrentDomain.SetupInformation.ApplicationName;
                                    Console.WriteLine("Hello from app domain " + appName);
                                });
                        });
                    var task2 = Task.Factory.StartNew(
                        () =>
                        {
                            RemoteAction.Invoke(
                                context2.Domain,
                                () =>
                                {
                                    var appName = AppDomain.CurrentDomain.SetupInformation.ApplicationName;
                                    Console.WriteLine("Hello from app domain " + appName);
                                });
                        });
                  
                    // Be sure to wait, else the domains will dispose
                    Task.WaitAll(task1, task2);
                }
                Console.ReadKey();
            }
        }
    }
