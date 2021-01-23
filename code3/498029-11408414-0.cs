    void Document_MouseDown(object sender, HtmlElementEventArgs e)
    {
        if(e.MouseButtonsPressed == MouseButtons.Right)
        {
            webBrowser.Document.ExecCommand("SelectAll", true, null);
        }
    }
