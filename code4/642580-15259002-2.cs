    [XmlRoot(("TERMS")]
    public class TermData
    {
        public TermData()
         {
           terms = new List<Term>();
         }
          
        [XmlElement("TERM")]
        public List<Term> terms{get;set;}
    }
    
    public class Term
    {
        [XmlElement("ID")]
        public string id{get;set;}
    
        [XmlElement("DESC")]
        public string desc{get;set;}
    }
