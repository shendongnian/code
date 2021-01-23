    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
    
        List<FontFamily> fontsFamilies = new List<FontFamily>(FontFamily.Families);
        if (!fontsFamilies.Exists(f => f.Name.Equals("Arial")))
        {
            //Install font from embeded resource here.
        }
    
        Application.Run(new Form1());
    }
