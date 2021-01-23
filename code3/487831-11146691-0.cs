    namespace WindowsFormsApplication1
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                var info = new ProcessStartInfo(@"calc.exe");
                var process = Process.Start(info);
                process.WaitForExit();
                MessageBox.Show("Hello World!");
            }
        }
    }
