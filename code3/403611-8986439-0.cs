    webBrowser1.Document.GetElementById("MainContent_LoginButton").Click += new HtmlElementEventHandler(test);
    
    // some code...
    
    public void test(object sender, HtmlElementEventArgs e)
    {
        MessageBox.Show("Clicked login button");
    }
