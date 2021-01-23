    private List<SomeInfo> ProcessItems(XmlTextReader reader)
    {
        List<SomeInfo> test = new List<SomeInfo>();
        while (reader.Read())
        {
            if (reader.Name.Equals("Item"))
            {
                var testObject = new SomeInfo();
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.EndElement && reader.Name.Equals("Item"))
                    {
                        break;
                    }
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "Item1":
                                testObject.Item1 = reader.ReadString();
                                break;
                            case "Item2":
                                testObject.Item2 = reader.ReadString();
                                break;
                        }
                    }
                }
                test.Add(testObject);
            }
        }
        return test;
    }
