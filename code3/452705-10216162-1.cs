    XDocument xDoc = XDocument.Load(new StringReader(xml));
    //Load Songs
    var songs = xDoc.Descendants("Song")
                    .Select(s => new
                    {
                        Artist = s.Element("artist").Value,
                        Track = s.Element("track").Value,
                        Column = s.Element("column").Value,
                        Date = s.Element("date").Value,
                    })
                    .ToArray();
    //Delete Songs
    string songByArtist="mic";
    xDoc.Descendants("Song")
        .Where(s => s.Element("artist").Value == songByArtist)
        .Remove();
    string newXml = xDoc.ToString();
