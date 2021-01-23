    public class empl
    {
         [XmlText]
         public string name { get; set; }
         [XmlAttribute]
         public int id { get; set; }
     }
    
     public class request
     {
          public empl employee { get; set; }
     }
     public Test()
     {
        XmlSerializer ser = new XmlSerializer(typeof(request));
        MemoryStream mem = new MemoryStream();
        ser.Serialize(mem , new request { employee = new empl { name="ff", id=6}});
        string dec = UTF8Encoding.UTF8.GetString(mem.ToArray());
     }
