    // make a list of the images you want to save
    List<XmlImage> images = new List<XmlImage>(Directory.GetFiles("imageDir")
        .Select(file => new XmlImage
                            { 
                               Title = System.IO.Path.GetFileNameWithoutExtension(file),
                               Source = file
                            }));
    // create an XmlSerializer for you list type
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<XmlImage>));
    // open file stream
    using (FileStream stream = new FileStream("destinationFile", FileMode.OpenOrCreate))
    {
        // save list to xml
        xmlSerializer.Serialize(stream, images);
    }
