        Object rssData = new object();
        Cms.UI.CommonUI.ApplicationAPI AppAPI = new Cms.UI.CommonUI.ApplicationAPI();
        rssData = AppAPI.ecmRssSummary(50, true, "DateCreated", 0, "");
        Response.ContentType = "text/xml";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(rssData.ToString());
        XmlNode node = xmlDocument.SelectSingleNode("rss/channel/item[title = 'Archived Planes']");
        if (node != null)
            try
            {
                node.ParentNode.RemoveChild(node);
                xmlDocument.Save(Response.Output);
            }
            catch { }
        else { Response.Write(rssData); }
    }
