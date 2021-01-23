    List<HtmlElement> links = null;
    private void button2_Click(object sender, EventArgs e)
    {
        // This way you only get the links once.
        links = new List<HtmlElement>(webBrowser1.Document.GetElementsByTagName("a")
                                                          .Cast<HtmlElement>());
    
        timer1.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        HtmlElement linkToClick = null;
    
        foreach (HtmlElement link in links)
        {
            if (link.GetAttribute("id").Contains("user"))
            {
                linkToClick = link;
                break;
            }
        }
        // did I find a link?
        if (linkToClick != null)
        {
            // Remove it from the list so you don't click it again.
            links.Remove(linkToClick);
    
            link.InvokeMember("click");
        }
    }
