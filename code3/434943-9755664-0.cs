    public abstract class Page<T> where T : class 
    { 
        public Func<T, object> SortBy { get; private set; } 
 
        public Page(Func<T, object> sortBy) 
        { 
            this.SortBy = sortBy; 
        } 
    } 
    public class ProductGridPage : Page<ProductGrid> 
    { 
        public ProductGridPage() : base(pg => pg.Title) 
        {  
 
        } 
    }
    public class ProductGrid
    {
      public string Title;
    }
