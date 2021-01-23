    public HelpForm()
    {
      InitializeComponent();
      
      string text = System.IO.File.ReadAllText(@"Docs\readme.html");
      webBrowser1.DocumentText = text;
    }
