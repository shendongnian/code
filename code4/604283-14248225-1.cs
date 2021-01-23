    public class IntegerValue() {
      [XmlText]
      public int value {get; set;}
      [XmlAnyAttribute]
      public string[] XAttributes {get; set;}
    }
