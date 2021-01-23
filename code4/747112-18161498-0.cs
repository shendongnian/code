    Dictionary<string, string> links = new Dictionary<string, string>();
    links.Add("Google","http://www.google.com");
    links.Add("StackOverflow", "http://www.stackoverflow.com");
    links.Add("CodeProject", "http://www.codeproject.com");
    int i = 0;
    linkLabel1.Text = "";
    foreach (KeyValuePair<string, string> link in links)
    {
         linkLabel1.Text += link.Key + "\n\n";
         linkLabel1.Links.Add(new LinkLabel.Link(i, link.Key.Length, link.Value));
         i = linkLabel1.Text.Length;
    }
    //Adding this to your form constructor would be OK
    linkLabel1.LinkBehaviour = LinkBehavior.HoverUnderline;    
    linkLabel1.LinkClicked += (s,e) => {
       System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
    };
