    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        var l = new Login();
        l.ShowDialog();
        if(l.Passed)
           Application.Run(new Login());
    }
