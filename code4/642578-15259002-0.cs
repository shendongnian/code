    [XmlRoot(("TERMS")]
    public class TermData
    {
        [XmlElement("TERM")]
        public List<Term> terms;
    }
    
    public class Term
    {
        [XmlElement("ID")]
        public string id;
    
        [XmlElement("DESC")]
        public string desc;
    }
