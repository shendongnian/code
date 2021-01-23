    /// <summary>
    /// Fixed version
    /// </summary>
    delegate HtmlDocument DlgGetDocumentFunc();
    public HtmlDocument GetDocument()
    {
    	if(InvokeRequired)
    	{
    		return (HtmlDocument)this.webBrowserMain.Invoke(new DlgGetDocumentFunc(GetDocument), new object[] { });
    	}
    	else
    	{
    		return this.webBrowserMain.Document;
    	}
    }
