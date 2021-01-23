    private void Print_Click(object sender, RoutedEventArgs e)
    {
    	// Try to print it as Html
    	var doc = webBrowser.Document as IHTMLDocument2;
    	if (doc != null)
    	{
    		doc.execCommand("Print", true, 0);
    		return;
    	}
    
    	// Try to print it as PDF
    	var pdfdoc = webBrowser.Document as AcroPDFLib.AcroPDF;
    	if (pdfdoc != null)
    	{
    		pdfdoc.Print();
    	}
    }
