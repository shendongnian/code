    [Serializable, XmlRoot(Namespace = "http://www.asd.com", ElementName = "botblpacientes", IsNullable = true)]
    public class BoTblPacientes
    {
       [XmlElement(ElementName = "tblpacientesid")]
        public Int32 tblpacientesid { get; set; }
           ...
        all the properties in lower case, due a xml has all in lower case. 
    }
