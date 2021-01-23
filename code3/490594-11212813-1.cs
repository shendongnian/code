    XDocument doc = XDocument.Load(openFileDialog1.FileName);
    List<XElement> docElements = doc.Elements().ToList();
    XElement results = docElements.Elements().Where(
       ele => ele.Name.LocalName == "Results").First();
    XElement firstRecord = results.Elements().Where(
       ele => ele.Name.LocalName == "Record").First();
    XElement recordImage = firstRecord .Elements().Where(
       ele => ele.Name.LocalName == "Image").First();
    string imageName = recordImage.Value;
