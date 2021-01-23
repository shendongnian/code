    [XmlRoot("Agency")]
    [XmlType(TypeName = "OrganizationType1", Namespace = "some-name-space")] 
    public class Agency 
    {
        [XmlElement("OrganizationAbbreviationText", Namespace = "some-name-space")]    
        public string OrganizationAbbreviationText { get; set; } 
    } 
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            string xml = "<Agency xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"" 
                        + " xmlns:nc=\"some-name-space\" xsi:type=\"nc:OrganizationType1\">"
                                + "<nc:OrganizationAbbreviationText>ABC</nc:OrganizationAbbreviationText>"
                        + "</Agency>";
            
            using (StringReader reader = new StringReader(xml)) 
            {     
                XmlSerializer ser = new XmlSerializer(typeof(Agency));
                var agency = (Agency)ser.Deserialize(reader);
                Console.WriteLine(agency.OrganizationAbbreviationText);
            } 
        }
    }
