        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var dlg = new OpenFileDialog();
            // Set dlg properties
            //...
            if (dlg.ShowDialog() == DialogResult.OK) {
                // Do something with dlg.FileName
                //...
            }
        }
