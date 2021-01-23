    public class Item : DbEntity
    {
        public string Name {get;set;}
        public int Quantity {get;set;}
    
        public Guid? CategoryId {get;set;}
        public virtual Category Category {get;set;}
    }
