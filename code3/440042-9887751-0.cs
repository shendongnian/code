    object yourType = new Object();
    
    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(yourType.GetType());
    
    x.Serialize(Console.Out,yourType);
