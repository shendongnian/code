    // Create the new nodes using doc
    XmlNode newSong = doc.CreateElement("Song");
    XmlNode artist = doc.CreateElement("artist");
    artist.InnerText = "Hello";
    // Begin the painstaking process of creation/appending
    newSong.AppendChild(artist);
    // rinse...repeat...
    // Finally add the new song to the SongsNode
    SongsNode.AppendChild(newSong);
