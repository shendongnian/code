        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();          // <=== HERE!
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
