    //This can be done a better way but using it for simplicity.
    //Create a Reader Object    System.IO.StreamReader sr = new System.IO.StreamReader(pathToFile);
    //get the contents of the file
    String xmlFileContents = sr.ReadToEnd();
    //close the file
    sr.Close();
    XmlDocument xDoc = new XmlDocument();
    //load the contents
    xDoc.LoadXml(xmlFileContents);
    
    //now you can traverse the nodes
    for (int i = 0; i < _xmlDocument.ChildNodes.Count; i++)
    {
        if (_xmlDocument.ChildNodes[i].Name == "RootNodeName")
        {
               //Do something
        }
    }
