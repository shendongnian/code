    using System;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.ApplicationServices;    // Add reference to Microsoft.VisualBasic
    
    namespace WindowsFormsApplication1 {
        class Program : WindowsFormsApplicationBase {
            public Program() {
                this.EnableVisualStyles = true;
                this.IsSingleInstance = true;
                this.MainForm = new Form1();
            }
            protected override void OnStartupNextInstance(StartupNextInstanceEventArgs e) {
                e.BringToForeground = true;
            }
            [STAThread]
            public static void Main(string[] args) {
                new Program().Run(args);
            }
        }
    }
