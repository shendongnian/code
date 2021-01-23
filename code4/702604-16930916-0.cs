    public class Product : DatabaseEntity
    {
        public int Id {get; set;}
        public int Name {get; set;}
        public decimal Price {get; set;}
    
        public ICollection<Product> ParentSimilars { get; set; }
        public ICollection<Product> ChildSimilars { get; set; }
            
        [NotMapped]
        public IEnumerable<Product> SimilarProducts
        {
            get
            {
               return ChildSimilars.Concat(ParentSimilars);
            }
        }
    
        ...
    }
