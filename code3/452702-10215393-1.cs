        XmlDocument doc = new XmlDocument();
        doc.Load(xmlFilePath);
        XmlNode versionNode = doc.SelectSingleNode(@"/xmlData/version");
        Console.WriteLine(versionNode.Name + ":\t" + versionNode.InnerText);
        XmlNode SongsNode = doc.SelectSingleNode(@"/xmlData/Songs");
        Console.WriteLine(SongsNode.Name + "\n");
        XmlNodeList SongList = doc.SelectNodes(@"/Songs/Song");
        if (SongList != null)
        {
            foreach (XmlNode SongNode in SongList)
            {
                XmlNode artistDetail = SongNode.SelectSingleNode("artist");
                Console.WriteLine(artistDetail.Name + "\t: " + artistDetail.InnerText);
                XmlNode trackDetail = SongNode.SelectSingleNode("track");
                Console.WriteLine(trackDetail.Name + "\t: " + trackDetail.InnerText);
                XmlNode columnDetail = SongNode.SelectSingleNode("column");
                Console.WriteLine(columnDetail.Name + "\t: " + columnDetail.InnerText);
                XmlNode dateDetail = SongNode.SelectSingleNode("date");
                Console.WriteLine(dateDetail.Name + "\t: " + dateDetail.InnerText + "\n");
            }
        }
