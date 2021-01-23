    [Serializable]
    class SomeProperty
    {
        public int Count1 {get;set;}   //2550
        public int Count2 {get;set;}   //995
        public int Count3 {get;set;}   //200000
        public int Count4 {get;set;}   //7
    }
    List<SomeProperty> objects=new List<SomeProperty>();
    objects.Add(...)
    //Saving
    XmlSerializer x = new XmlSerializer(objects.GetType());
    using (FileStream stream = System.IO.File.Create(FilePath))
    {
        XmlWriter writer = XmlWriter.Create(stream);
        x.Serialize(writer, objects);
    }
    
    //Reading
    XmlSerializer x = new XmlSerializer(typeof(List<SomeProperty>));
    using (FileStream fs = new FileStream(FilePath, FileMode.Open))
    {
        XmlReader reader = new XmlTextReader(fs);
        var objects= (List<SomeProperty>)x.Deserialize(reader);
    }
    
