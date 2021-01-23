    public class Card
    {
        public Guid Id{get;set;}
        public ICollection<DocumentLink> DocumentLinks{get;set;}
        public ICollection<Charge> Charges{get;set;}
    }
    
    public class Charge
    {
        ...
        public ICollection<DocumentLink> DocumentLinks{get;set;}
    }
    
    public class DocumentLink
    {
        ...
    }
