    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        string path = @"c:\Path\Path2\file.txt";
        if (!File.Exists(path))
        {
            Application.Run(new form2());
        }
        else
        {
            Application.Run(new form1());
        }
    }
