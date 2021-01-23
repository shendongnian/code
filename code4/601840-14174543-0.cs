    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var cms = new ContextMenuStrip();
            cms.Items.Add("Show", null, ShowForm);
            cms.Items.Add("Exit", null, ExitProgram);
            var ni = new NotifyIcon();
            ni.Icon = Properties.Resources.SampleIcon;
            ni.ContextMenuStrip = cms;
            ni.Visible = true;
            Application.Run();
            ni.Dispose();
        }
        private static void ShowForm(object sender, EventArgs e) {
            // Ensure the window acts like a singleton
            if (MainWindow == null) {
                MainWindow = new Form1();
                MainWindow.FormClosed += delegate { MainWindow = null; };
                MainWindow.Show();
            }
            else {
                MainWindow.WindowState = FormWindowState.Normal;
                MainWindow.BringToFront();
            }
        }
        private static void ExitProgram(object sender, EventArgs e) {
            Application.ExitThread();
        }
        private static Form MainWindow;
    }                                                                
