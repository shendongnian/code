    public class PartDetail
    {
      [XmlAttribute]
      public string ID{ get; set; }
    
      public string OEMNumbers { get; set; }
    
      public List<VehicleApplication> VehicleApplications { get; set; }
    }
    public class PartInfo
    {
      public PartDetail { get; set; }
    }
