    XmlDocument RSSXml = new XmlDocument();
    RSSXml.Load("Kotaku - powered by FeedBurner.xml");
    XmlNodeList RSSNodeList = RSSXml.SelectNodes("rss/channel/item");
    StringBuilder sb = new StringBuilder();
    foreach (XmlNode RSSNode in RSSNodeList)
    {
        XmlNode RSSSubNode;
        RSSSubNode = RSSNode.SelectSingleNode("title");
        string title = RSSSubNode != null ? RSSSubNode.InnerText : "";
        RSSSubNode = RSSNode.SelectSingleNode("link");
        string link = RSSSubNode != null ? RSSSubNode.InnerText : "";
        RSSSubNode = RSSNode.SelectSingleNode("description");
        string desc = RSSSubNode != null ? RSSSubNode.InnerText : "";
        RSSSubNode = RSSNode.SelectSingleNode("pubDate");
        string pubDate = RSSSubNode != null ? RSSSubNode.InnerText : "";
        sb.Append("<font face='arial'><p><b><a href='");
        sb.Append(link);
        sb.Append("'>");
        sb.Append(title);
        sb.Append("</a></b><br/>");
        sb.Append(desc);
        sb.Append(pubDate);
        sb.Append("</p></font>");
    }
    textBox1.Text = sb.ToString();
