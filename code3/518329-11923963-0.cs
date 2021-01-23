    using System;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.ApplicationServices;   // Add reference to Microsoft.VisualBasic
    
    namespace WindowsFormsApplication1 {
        class Program : WindowsFormsApplicationBase {
            static void Main(string[] args) {
                var app = new Program();
                app.Run(args);
            }
            public Program() {
                this.IsSingleInstance = true;
                this.EnableVisualStyles = true;
                this.MainForm = new Form1();
            }
            protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs) {
                if (this.MainForm.WindowState == FormWindowState.Minimized) this.MainForm.WindowState = FormWindowState.Normal;
                this.MainForm.Activate();
            }
        }
    }
