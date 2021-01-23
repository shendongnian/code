    public abstract class A<TProduct> where TProduct : ProductBase 
    {
        protected abstract void addProduct(TProduct p);
    }
    
    public class B : A<ProductBase>
    {        
        protected override void addProduct(ProductBase p)
        {
        }
    }
    
    public class C : A<SomeProduct>
    {
        protected override void addProduct(SomeProduct p)
        {
        }
    }
