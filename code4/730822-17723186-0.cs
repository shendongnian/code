        /// <summary>
        /// Program entry point
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // ...
            // close the form after you change the language:
            //     DialogResult = DialogResult.Cancel;
            // exit with any other value
            DialogResult result;
            do
            {
                 MainForm form = new MainForm();
                 result = form.ShowDialog()
            } while(result == DialogResult.Cancel);
        }
