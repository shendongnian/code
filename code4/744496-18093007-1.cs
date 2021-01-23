    private void button1_Click(object sender, EventArgs e)
    {
        Scrapper scrapper = new Scrapper(this);
        scrapper.login(webBrowser1);  
    }
    
    public void updateLoginWeb(WebBrowser web)
    {
        //webBrowser1 = web;  // you don't need this anymore
        MessageBox.Show("DONE");
    }
