    namespace TestService 
    {
       static class Program
       {
            [DllImport("kernel32.dll")]
            static extern bool AllocConsole();
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            static void Main()
            {
                if (!Environment.UserInteractive)                                
                {
                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[] 
                    { 
                        new Service1() 
                    };
                    ServiceBase.Run(ServicesToRun);
                }
                else 
                {
                    AllocConsole();
                    //Start Code that interfaces with console.
                }           
             }        
         }
     }
