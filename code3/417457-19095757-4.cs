    richTextBox.IsDocumentEnabled = true;
    
    TextPointer t1 = richTextBox1.Document.ContentStart;
    TextPointer t2 = richTextBox1.Document.ContentEnd;
    TextRange tr = TextRange(t1,t2);
    string URI = tr.Text;
    
    Hyperlink link = new Hyperlink(t1, t2);
    
    link.IsEnabled = true;
    link.NavigateUri = new Uri(URI); 
    link.RequestNavigate += new RequestNavigateEventHandler(link_RequestNavigate);
    
    
    private void link_RequestNavigate(object sender,RequestNavigateEventArgs e)
    {
        System.Diagnostics.Process.Start(e.Uri.AbsoluteUri.ToString());
    }
