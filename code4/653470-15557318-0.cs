    private string[] get_news(string URL)
    {
        XmlTextReader textReader = new XmlTextReader(URL);
        string[] newsy;
        while (textReader.Read())
        {
            if (textReader.NodeType == XmlNodeType.Element)
            {
                if (textReader.Name == "news") {
                    string News = textReader.ReadElementContentAsString();
                    newsy = { News };
                }
                if (textReader.Name == "link")
                {
                    string Link = textReader.ReadElementContentAsString();
                    newsy = { Link };
                }
            }
        }
        return newsy;
    }
