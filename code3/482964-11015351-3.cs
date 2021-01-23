    public abstract class A<T>
        where T : ProductBase
    {
        protected abstract void addProduct(T p);
        
        protected void addProductUntyped(ProductBase p)
        {
            T typedProduct = p as ProductBase;
            if (typedProduct != null) {
                addProduct(typedProduct);
            } else {
                throw new ArgumentException("p has an incompatible type.");
            }
        }
    }
