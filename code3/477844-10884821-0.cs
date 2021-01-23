    public static void SaveBehaviors(ObservableCollection<Param> listParams)
    {
        XmlSerializer _paramsSerializer = new XmlSerializer(listParams.GetType());
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        path += "\\test.xml";
        using (TextWriter writeFileStream = new StreamWriter(path))
        {
            _paramsSerializer.Serialize(writeFileStream, listParams);
            using (XmlDocument doc = new XmlDocument())
            {
                doc.Load(path);//load from the saved document
                XmlNode fooNode = doc.CreateElement("foo");//create node
                XmlAttribute fooAtt = doc.CreateAttribute("bar");//create attribute
                fooAtt.InnerText = "some att data";//set data
                fooNode.InnerText = "some node text";//set data
                fooNode.Attributes.Append(fooAtt);//add attribute to node
                doc.DocumentElement.AppendChild(fooNode);//add node to document
                doc.Save(path);//save the changes made
            }
        }
    }
