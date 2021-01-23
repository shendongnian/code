      [XmlType(TypeName="item")]
      public class Item {
        public string Name { get; set; }
        public decimal Price { get; set; }
      }
      [XmlRoot(ElementName = "root")]
      public class ItemList : List<Item> {
      }
