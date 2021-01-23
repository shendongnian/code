    public class ProductRepository : RavenDbRepository<Product>
    {
        public override Product Get(object id)
        {
            return GetAll().FirstOrDefault(x => x.ProductNumber == id);
        }
        public override Delete(Product item)
        {
            throw new NotSupportedException("Products can't be deleted from db");
        }
    }
