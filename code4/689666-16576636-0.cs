    class CartGroupComparer : IEqualityComparer<CartProduct>
    {
        public bool Equals(CartProduct x, CartProduct y)
        {
            return x.IDLocation == y.IDLocation
                 && x.ShipMethods.OrderBy(x=>x)
                       .SequenceEqual(y.ShipMethods.OrderBy(x=>x));
        }
        public int GetHashCode(CartProduct obj)
        {
            return obj.IDLocation.GetHashCode() 
                    ^ obj.ShipMethods.Sum().GetHashCode();
        }
    }
