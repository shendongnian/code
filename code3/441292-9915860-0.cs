    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    namespace Logger
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MainForm mainForm = new MainForm();
                mainForm.OnStart();
                Application.Run(mainForm);  
                mainForm.OnStop()
            }
        }
    }
