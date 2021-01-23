    [STAThread]
    public static void Main() {
        
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        using(MainForm form = new MainForm()) {
            Application.Run(form);
        }
    }
