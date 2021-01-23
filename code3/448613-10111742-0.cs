    public class Item {
      [XmlElement("someDetail")]
      public string SomeDetail;
    } // class Item
    [XmlRoot("items")]
    public class MyData {
      [XmlElement("item")]
      public List<Item> Items;
      public static MyData Deserialize(Stream source)
      {
        XmlSerializer serializer = new XmlSerializer(typeof(MyData));
        return serializer.Deserialize(source) as MyData;
      } // Deserialize
    } // class MyData
