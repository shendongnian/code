     bob.MyEnum = (MyEnum)Enum.Parse(typeof(MyEnum), "Single");
   
     public enum MyEnum {
       [System.Xml.Serialization.XmlEnumAttribute("Single")]
       Item1,
       Item2
     }
