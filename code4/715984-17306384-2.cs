    public class Category 
    {
        public virtual ICollection<Product> Products { get; set; }
        public IQueryable<Products> NonDeletedProductts() 
        {
            return this.Products.Where(e => e.IsDeleted == false);
        }
    }
        
