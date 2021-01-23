    public class BMW : Car
    {
      // put properties and methods specific to this type here
      [XmlAttribute("NavVendor")]
      public string navigationSystemVendor { get; set; }
    }
    public class Acura : Car
    {
      // put properties and methods specific to this type here
      [XmlAttribute("SunroofTint")]
      public bool sunroofTint { get; set; }
    }
