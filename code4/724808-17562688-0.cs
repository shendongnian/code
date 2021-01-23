    public interface IRepository<T>
    {
        List<string> GetColumnNames();
        IQueryable<T> GetAll();
    }
    public class CatalogItemRepository : IRepository<CatalogItem>
    {
        private string repositoryName="CatalogItem";
        public List<string> GetColumnNames()
        {
           //implementation
        }
        
        public IQueryable<CatalogItem> GetAll()
        {
           //implementation
        }
    }
