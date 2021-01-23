    using System.Linq;
    
    namespace MyClassLibrary
    {
        public interface ICategoryDataSource
        {
            IQueryable<Product> Products { get; }
            IQueryable<Category> Categories { get; }
        }
    }
