    using System;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace Sandbox_Form
    {
        static class Program
        {
            private static Thread thread;
    
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                thread = new Thread(BusyWorkThread);
                thread.IsBackground = false;
                thread.Start();
    
                Application.Run(new Form());
    
            }
    
            public static void BusyWorkThread()
            {
                while (true)
                {
                    Thread.Sleep(1000);
                }
            }
        }
    }
