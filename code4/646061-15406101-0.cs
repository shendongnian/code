    // Pseudo code
    private string _content = string.empty;
    
    private void frmMain_Load(object sender, EventArgs e)
    {
    	// This tells the browser that any javascript requests that call "window.external..." to use this form, useful if you want to hook up events so the browser can notify us of things via JavaScript
    	webBrowser1.ObjectForScripting = this;
    	webBrowser1.Url = new Uri("yourUrlHere");
    }
    
    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
    	// Store original content
    	_content = webBrowser1.Content;	// Pseudo code
    	webBrowser1.Document.Click += new HtmlElementEventHandler(Document_Click);
    	webBrowser1.Document.PreviewKeyDown +=new PreviewKeyDownEventHandler(Document_PreviewKeyDown);
    }
    
    protected void Document_Click(object sender, EventArgs e)
    {
    	DocumentChanged();
    }
    
    protected void Document_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
    	DocumentChanged();
    }
    
    private void DocumentChanged()
    {
    	// Compare old content with new content
    	if (_content == webBrowser1.Content)	// Pseudo code
    	{
    		// No changes made...
    		return;
    	}
    	
        // Add code to handle the change
        // ...
    	// Store current content so can compare on next event etc
    	_content = webBrowser1.Content;	// Pseudo code
    }
