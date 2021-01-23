        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            Application.CurrentCulture.DateTimeFormat.DateSeparator = "/";
            Application.Run(new MainForm());
        }
