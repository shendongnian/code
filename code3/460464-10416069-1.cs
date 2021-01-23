    namespace WpfConsoleTest
    {
        public partial class App : Application
        {
            protected override void OnStartup(StartupEventArgs e)
            {
                ConsoleHelper.AllocConsole(); 
                Console.WriteLine("Start");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Stop");
                ConsoleHelper.FreeConsole();
                Shutdown(0);
            }
        }
    }
