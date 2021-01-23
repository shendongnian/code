    public void button1_Click(object sender, EventArgs e)
    {
        webBrowser1.Document.GetElementById("q").SetAttribute("value", "חחח");
        webBrowser1.Document.GetElementById("btnK").InvokeMember("Click");
        while (true)
       {
           System.Windows.Forms.Application.DoEvents();
            if(webBrowser1.Document.GetElementById("pnnext") != null)
            break;
       }
  
        webBrowser1.Document.GetElementById("pnnext").InvokeMember("Click");
        webBrowser1.Document.GetElementById("q").Focus();
    }
