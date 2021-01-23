    [XmlRoot("order")]
    public class order
    {
    [XmlElement("Number")]
    public string  Number{get;set;}
    [XmlElement("Email")]
    public string  Email{get;set;}
    [XmlElement("Date")]
    public string  Date{get;set;}
    [XmlElement("File")]
    public string[] File{get;set;}
    }
