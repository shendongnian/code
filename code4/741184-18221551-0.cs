    string ShStory=null;
    string Title = null;
    
    //Creating a XML Document
    XmlDocument doc = new XmlDocument();  
    
    //Loading rss on it
    doc.Load("http://news.yahoo.com/rss/");
    
    //Looping every item in the XML
    foreach (XmlNode node in doc.SelectNodes("rss/channel/item"))
    {
        //Reading Title which is simple
        Title = node.SelectSingleNode("title").InnerText;
    
        //Putting all description text in string ndd
        string ndd =  node.SelectSingleNode("description").InnerText;
        XmlDocument xm = new XmlDocument();
    
        //Loading modified string as XML in xm with the root <me>
        xm.LoadXml("<me>"+ndd+"</me>");
        //Selecting node <p> which has the text
        XmlNode nodds = xm.SelectSingleNode("/me/p");
       //Putting inner text in the string ShStory
        ShStory= nodds.InnerText;
       //Showing the message box with the loaded data
        MessageBox.Show(Title+ "    "+ShStory); 
    }
