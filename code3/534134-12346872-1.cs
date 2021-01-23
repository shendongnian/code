    private bool wbNeedsSpecialAction; //when you need to call the special case of Navigate() set this flag to true
    public Form1() 
    {
        InitializeComponent();         
        wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
    }
    void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        if (wbNeedsSpecialAction)
        {
            richtextdocument.Text = wb.DocumentText;
            wbNeedsSpecialAction = false;
        }
        else
        {
            //other cases of using DocumentCompleted...
        }
    }
    
    public void Browse()
    {
        wbNeedsSpecialAction = true; //make sure the event is treated differently
        wb.Navigate("http://www.google.com");
    }
