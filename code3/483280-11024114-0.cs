    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace Prueba {
        static class Program {
            [STAThread]
            static void Main() {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                //This is the magic line code :P
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            }
            static void CurrentDomain_ProcessExit(object sender, EventArgs e) {
                MessageBox.Show("");
            }
        }
    }
