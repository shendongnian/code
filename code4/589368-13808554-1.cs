    static IEnumerable<CaseFile> FindCaseFiles(string uri)
    {
        using (XmlReader reader = XmlReader.Create(uri))
        {
            reader.MoveToContent();
            
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "case-file")
                        {
                            XElement el = XElement.ReadFrom(reader) as XElement;
                            if (el != null)
                                yield return new CaseFile() {...};
                        }
                        break;
                }
            }
        }
    }
