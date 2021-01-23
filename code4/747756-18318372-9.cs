    bool _loaded = false;
    
    public Form1()
    {
    	InitializeComponent();
    
    	this.WB.DocumentCompleted += WB_DocumentCompleted;
    }
    
    void WB_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
    	if (_loaded)
    		return;
    	_loaded = true;
    
    	HtmlElement link = null;
    	if (FindLinkToClick(this.WB.Document.Body, "Wereld 33", ref link))
    	{
    	  link.InvokeMember("click", null);
    	}
    }
    
    void Form1_Load(object sender, EventArgs e)
    {
    	this.WB.Navigate(@"http://scriptsenprogs.nl/twmc.html");
    }
 
