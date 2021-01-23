    [XmlRoot("Employee"), Serializable]    
    public class Employee    
    {    
     [XmlAnyElement]
     public object [] EmployeeDetails    { get; set; }
    
     [XmlElement("Transcation")]
     public List<Transcation> Transcations { get; set; }
    }
