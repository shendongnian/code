        bool DeleteSongByArtist(XmlDocument doc, string artistName)
        {
            XmlNodeList SongList = doc.SelectNodes(@"/Songs/Song");
            if (SongList != null)
            {
                for (int i = SongList.Count - 1; i >= 0; i--)
                {
                    if (SongList[i]["artist"].InnerText == artistName && SongList[i].ParentNode != null)
                    {
                        SongList[i].ParentNode.RemoveChild(SongList[i]);
                    }
                }
            }
        }
