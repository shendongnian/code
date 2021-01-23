    private string[] get_news(string URL)
        {
            string [] newsy;
            XmlTextReader textReader = new XmlTextReader(URL);
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
