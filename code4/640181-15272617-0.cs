    HtmlElementCollection links = webBrowser1.Document.GetElementsByTagName("A");
    
    links = webBrowser1.Document.GetElementsByTagName("textarea");
    foreach (HtmlElement link in links)
    {
    	if ((link.GetAttribute("Name") == "text"))
    	{
    		string attribute = link.InnerText;
    		string replace = attribute.Replace(@"Hello World", @"Helo World!!!");
    		link.InnerText = replace;
    		break;
    	}
    }
    
    links = webBrowser1.Document.GetElementsByTagName("input");
    foreach (HtmlElement link in links)
    {
    	if ((link.GetAttribute("Name") == "Save"))
    	{
    		if (link.GetAttribute("type").Equals("submit"))
    		{
    			link.InvokeMember("click");
    			break;
    		}
    	}
    }
