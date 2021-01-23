        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form main;
            if (System.Diagnostics.Debugger.IsAttached) main = new Form2();
            else main = new Form1();
            Application.Run(main);
        }
