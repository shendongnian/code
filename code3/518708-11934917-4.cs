    XmlSerializer serializer = new XmlSerializer(typeof(Eventi));
    XDocument document = XDocument.Parse(e.Result);
    Eventi eventi = (Eventi)serializer.Deserialize(document.CreateReader());
    foreach (Evento obj in eventi.Collect)
    {
        Debug.WriteLine("Title: {0}", obj.title);
        Debug.WriteLine("Img: {0}", obj.image.url); // Retrieving image URL
    }
