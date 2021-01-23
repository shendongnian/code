    public class Category {
        public Int32 Id { get; set; }
    }
    
    public class SomeClass {
        public Int32 Id { get; set; }
        public virtual Category Category { get; set; }
    }
