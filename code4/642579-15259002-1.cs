    [XmlRoot(("TERMS")]
    public class TermData
    {
        public TermData()
         {
           terms = new List<Term>();
         }
          
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
