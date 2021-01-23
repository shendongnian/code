    public class FindProducts : IReturn<List<Product>> {
        public string Category { get; set; }
        public decimal? PriceGreaterThan { get; set; }
    }
    public class GetProduct : IReturn<Product> {
        public int? Id { get; set; }
        public string Name { get; set; }
    }
    public class ProductsService : Service 
    {
        public object Get(FindProducts request) {
            var ret = products.AsQueryable();
            if (request.Category != null)
                ret = ret.Where(x => x.Category == request.Category);
            if (request.PriceGreaterThan.HasValue)
                ret = ret.Where(x => x.Price > request.PriceGreaterThan.Value);            
            return ret;
        }
        public Product Get(GetProduct request) {
            var product = request.Id.HasValue
                ? products.FirstOrDefault(x => x.Id == request.Id.Value)
                : products.FirstOrDefault(x => x.Name == request.Name);
            if (product == null)
                throw new HttpError(HttpStatusCode.NotFound, "Product does not exist");
            return product;
        }
    }
