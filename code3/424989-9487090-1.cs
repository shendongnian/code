    [DllImport("gdi32", EntryPoint = "AddFontResource")]
    public static extern int AddFontResourceA(string lpFileName);
    
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
    
        List<FontFamily> fontsFamilies = new List<FontFamily>(FontFamily.Families);
        if (!fontsFamilies.Exists(f => f.Name.Equals("Arial")))
        {
            //Save the font from resource here....
    
    
            //Install the font
            int result = AddFontResourceA(@"C:\MY_FONT_LOCATION\Arial.TTF");
        }
    
        Application.Run(new Form1());
    }
