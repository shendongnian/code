    public static string ShowEmbeddedVideo(string youtubeObject)
    {
        var xdoc = XDocument.Parse(youtubeObject);
        var returnObject = string.Format("<object type=\"{0}\" data=\{1}\"><param name=\"movie\" value=\"{1}\" />",
            xdoc.Root.Element("embed").Attribute("type").Value,
            xdoc.Root.Element("embed").Attribute("src").Value);
        return returnObject;
    }
