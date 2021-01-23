    Queue<string> _items;
    private void button1_Click_1(object sender, EventArgs e)
    {        
        String text = File.ReadAllText("links.txt");
        _items = new Queue<string>(Regex.Split(text, "\r\n|\r|\n"));
        webBrowser2.ScriptErrorsSuppressed = true;
        webBrowser2.DocumentCompleted += webBrowser2_DocumentCompleted;
        RequestItem();
    }
    private void RequestItem()
    {
        if (_items.Any())
        {
            var url = _items.Dequeue(); // preprocess as required
            webBrowser2.Navigate(url);
        }
    }
    void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        // Handle result
        RequestItem(); // Then request next item
    }
