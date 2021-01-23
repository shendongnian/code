    void Main()
    {
    	WebBrowser webBrowser1 = new WebBrowser();
    	webBrowser1.DocumentTitleChanged +=
            new EventHandler(ProcessDocument);
    	webBrowser1.Navigate("http://localhost/test/test.html"); 
    
    	Console.ReadLine();
    }
    
    // Define other methods and classes here
    private void ProcessDocument(object sender,
        EventArgs e)
    {
    
        var webBrowser1 = (WebBrowser)sender;
        Console.WriteLine("ProcessDocument BEGIN");
        HtmlElementCollection links = webBrowser1.Document.GetElementsByTagName("A");
        foreach (HtmlElement link in links)
        {
            Console.WriteLine(link.GetAttribute("href"));         
        }
    	Console.WriteLine("ProcessDocument END");
    	Console.Out.Flush();
    
    }
