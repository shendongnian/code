    var xDoc = XDocument.Parse(Resource1.XMLFile1); // loading source xml
    var xmls = xDoc.Root.Elements().ToArray(); // split into elements
    for(int i = 0;i< xmls.Length;i++)
    {
        // write each element into different file
        using (var file = File.CreateText(string.Format("xml{0}.xml", i + 1)))
        {
            file.Write(xmls[i].ToString());
        }
    }
