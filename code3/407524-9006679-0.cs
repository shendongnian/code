    namespace TestService 
    {
       static class Program
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr GetStdHandle(int nStdHandle);
            const int STD_OUTPUT_HANDLE = -11;
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            IntPtr iStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
            bool runAsWindowsService = false;
            
            if (iStdOut == IntPtr.Zero)
            {    
                runAsWindowsService = true;
            }
            if (runAsWindowsService)                                
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
