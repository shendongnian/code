        var data = from query in loadedData.Descendants("singer")
                   select new Singer
                   {
                       name = (string)query.Element("name"),
                       song = (string)query.Element("song"),
                       akor = (string)query.Element("lyrics")
                   }.GroupBy(ex => ex.name);
