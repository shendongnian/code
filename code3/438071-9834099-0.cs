    Test test = new Test() { Test1 = "1", Test2 = "3" };
    System.Xml.Serialization.XmlSerializer x = new   System.Xml.Serialization.XmlSerializer(test.GetType());
    MemoryStream ms = new MemoryStream();
    x.Serialize(ms, test);
    ms.Position = 0;
    StreamReader sr = new StreamReader(ms);
    string xml = sr.ReadToEnd();
