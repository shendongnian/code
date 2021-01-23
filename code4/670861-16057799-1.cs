    public class Card
    {
        public Guid Id{get;set;}
        public virtual ICollection<DocumentLink> DocumentLinks{get;set;}
        public virtual ICollection<Charge> Charges{get;set;}
    }
    
    public class Charge
    {
        ...
        public virtual ICollection<DocumentLink> DocumentLinks{get;set;}
    }
    
    public class DocumentLink
    {
        ...
    }
