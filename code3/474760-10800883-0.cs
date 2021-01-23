    public class Specification<T>
    {
        Func<T, bool> _spec;
        public Specification(Func<T, bool> spec)
        {
            _spec = spec;
        }
        public bool IsSatisifedBy(T item)
        {
            return _spec(T);
        }
    }
    // ...
    _cheapProductsSpecification = new Specification<Product>(p => p.Price < 5);
    var cheapProducts = Basket.Products.Where(p => _cheapProductsSpecification.IsSatifisifedBy(p));
