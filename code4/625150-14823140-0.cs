    private void Form1_Load(System.Object sender, System.EventArgs e)
    {
        webBrowser1.Navigate("http://halo.bungie.net/Stats/Halo3/Default.aspx?player=SmitherdxA27");
    }
    private void WebBrowser1_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
    {
        if ((e.Url.ToString() == "http://halo.bungie.net/Stats/Halo3/Default.aspx?player=SmitherdxA27"))
        {
            HtmlElement elem = webBrowser1.Document.GetElementById("ctl00_mainContent_identityStrip_EmblemCtrl_imgEmblem");
            string src = elem.GetAttribute("src");
            this.pictureBox1.ImageLocation = src;
        }
    }
