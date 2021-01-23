    public class place
    {
        [XmlElement("pID")]
        public string placeID { get; set; }
        [XmlElement("pCatID")]
        public string placeCatID { get; set; }
        [XmlElement("pName")]
        public string placeName { get; set; }
    }
    // To write the placeList variable contents to XML.
    WriteToXmlFile<List<place>>("C:\places.txt", placeList);
    
    // To read the xml file contents back into a variable.
    List<place> placeList= ReadFromXmlFile<List<place>>("C:\places.txt");
