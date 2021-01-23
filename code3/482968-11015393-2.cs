    public abstract class A
    {
        protected void addProduct(ProductBase p) { addProductImpl(p);}
        protected abstract void addProductImpl(ProductBase p);
    }
    public class C : A
    {
        new protected void addProduct(SomeProduct p) { addProductImpl(p);}
        protected override void addProductImpl(ProductBase p)
        {
            SomeProduct prod = (SomeProduct) p;
            // ...
        }
    }
