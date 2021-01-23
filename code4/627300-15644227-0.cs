    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace SampleApp
    {
        class Program
        {
            [DllImport("kernel32.dll", SetLastError=true, CallingConvention=CallingConvention.Winapi)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool AllocConsole();
            
            [DllImport("kernel32.dll", SetLastError=true, CallingConvention=CallingConvention.Winapi)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool FreeConsole();
            
            [STAThread]
            private static void Main(string[] args)
            {
                // (1) Make sure we have a console to use.
                Program.AllocConsole();
                try {
                    // (2) Tell log4net to configure itself according to our app.config data.
                    log4net.Config.XmlConfigurator.Configure();
                    // (3) Usual WinForms startup code here.
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new SampleApp.Form1());
                } catch ( Exception ) {
                    // WAT!
                }
                // (4) Remember to release the console before we exit.
                Program.FreeConsole();
            }
        }
    }
