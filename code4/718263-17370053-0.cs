    XDocument doc = XDocument.Load("Music.xml");
    var data = doc.Descendants("singer").Select(x => new Singer {
        Name = (string)x.Element("name"),
        Song = (string)x.Element("song"),
        Lyrics = (string)x.Element("lyrics")
    });
    List<string> dataToBind = data.Select(x => x.Name).Distinct().ToList();
