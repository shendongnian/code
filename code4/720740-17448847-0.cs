     XmlDocument xml = new XmlDocument();
            xml.LoadXml(urXml);
        XmlNodeList textlist = xml.GetElementsByTagName("text");
        XmlNodeList contentList = xml.GetElementsByTagName("content");
        for (int i = 0; i < textlist.Count; i++)
        {
            string s1 = textlist[i].InnerText; //
        }
        for (int j = 0; j < contentList.Count; j++)
        {
            string s2 = contentList[j].InnerText;
        }
