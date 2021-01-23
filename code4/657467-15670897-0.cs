    [XmlRoot("Show")]`
    public class Show
    {
       [XmlIgnore()]
       public ShowStatus status { get; set; }
       
       [XmlElement(ElementName = "status")]
       public string StatusString
       {
           get { return status.ToString(); }
           set { status = Enum.Parse(ShowStatus, value); }
       }
    }
