    public void updateLoginWeb(WebBrowser web)
    {
        Controls.Remove(webBrowser1);
        Controls.Add(web);
        webBrowser1 = web;  // you don't need this anymore
        MessageBox.Show("DONE");
    }
