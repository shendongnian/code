    //This can be done a better way but using it for simplicity.
    //Create a Reader Object    
    System.IO.StreamReader sr = new System.IO.StreamReader(pathToFile);
    //get the contents of the file
    String xmlFileContents = sr.ReadToEnd();
    //close the file
    sr.Close();
    XmlDocument _xDoc = new XmlDocument();
    //load the contents
    _xDoc.LoadXml(xmlFileContents);
    
    //now you can traverse the nodes
    for (int i = 0; i < _xDoc.ChildNodes.Count; i++)
    {
        if (_xDoc.ChildNodes[i].Name == "url")
        {
               //Do something like
               // string theUrl = _xDoc.ChildNodes[i].InnerText;
        }
    }
