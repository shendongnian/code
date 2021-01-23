    namespace WpfConsoleTest
    {
        public partial class App : Application
        {
            [DllImport("Kernel32.dll")]
            public static extern bool AttachConsole(int processId);
            protected override void OnStartup(StartupEventArgs e)
            {
                AttachConsole(-1);
                Console.WriteLine("Start");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Stop");
                Shutdown(0);
            }
        }
    }
