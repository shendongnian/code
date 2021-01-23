    public class IntegerValue() {
      [XmlText]
      public int value {get; set;}
      [XmlAny]
      public string[] XAttributes {get; set;}
    }
