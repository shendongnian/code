    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new LogAnalizzer());
        ListService.Dispose();   // or whatever you're going to call it
    }
