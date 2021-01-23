     public class ProductCountryEqualityComparer : IEqualityComparer<Product>
        {
    
            #region IEqualityComparer<Product> Members
    
            public bool Equals(Product x, Product y)
            {
                return x != null && y != null && x.Country  == y.Country;
            }
    
            public int GetHashCode(Product obj)
            {
                return 0;
            }
    
            #endregion
        }
