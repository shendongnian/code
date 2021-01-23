    //This list gets populated somewhere else with all the existing id's...
    List<int> allId = new List<int>();
    doc = new XmlDocument();
    doc.Load(Server.MapPath("../data/blog.xml"));
    XmlNodeList list = doc.SelectNodes("div/span");
    int newId = 1;
    for (int i = 0; i < list.Count + 1; i++)
    {
        if (allId.Contains(newId))
        {
            newId++;
        }
        else
        {
            string blogText = txtCreateBlog.Text;
            string blogDate = DateTime.Now.Day + " " + DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Year + " - " + DateTime.Now.ToString("hh:mm tt") + " #" + newId.ToString();
                            
            XmlNode newNode = doc.SelectSingleNode("div/span[@id=\"1\"]");
            XmlElement span = doc.CreateElement("span");
            span.SetAttribute("id", newId.ToString());
            doc.DocumentElement.PrependChild(span);
            span.SelectSingleNode("div/span[@id=\"" + newId.ToString() + "\"]");
    
            XmlNode newNode2 = doc.SelectSingleNode("div/span[@id=\"" + newId.ToString() + "\"]");
            XmlElement a = doc.CreateElement("a");
            a.SetAttribute("class", "time");
            a.InnerText = blogDate.ToString();
            span.AppendChild(a);
    
            XmlNode newNode3 = doc.SelectSingleNode("div/span[@id=\"" + newId.ToString() + "\"]");
            XmlElement p = doc.CreateElement("p");
            p.SetAttribute("class", "post");
            p.InnerText = blogText.ToString();
            span.AppendChild(p);
    
            XmlNode newNode4 = doc.SelectSingleNode("div/span[@id=\"" + newId.ToString() + "\"]");
            XmlElement br = doc.CreateElement("br");
            span.AppendChild(br);
    
            doc.Save(Server.MapPath("../data/blog.xml"));
    }
