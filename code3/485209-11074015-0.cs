    public partial class App : Application {
        private void Application_Startup(object sender, StartupEventArgs e) {
    #if DEBUG
            AllocConsole();
            Console.WriteLine("Hello world");
    #endif
        }
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
    }
