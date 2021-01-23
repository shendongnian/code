    static void Main(string[] args)
    {
        string url = "";
        if (args.Length > 0)
            url = args[0];
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new frmGetText(url));
        
        ....
