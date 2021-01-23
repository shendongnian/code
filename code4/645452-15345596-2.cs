    class Product { 
        public int ID {get; set;}
        public string Name {get; set;} 
        public string Description {get; set;}
        public decimal Price {get; set;}
        public virtual ICollection<Category> Categories { get; set; }
    }
