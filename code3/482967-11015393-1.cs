    public abstract class A<T> where T : ProductBase
    {
        protected abstract void addProduct(T p);
    }
    public class C : A<SomeProduct>
    {
        protected override void addProduct(SomeProduct p)
        {
            // ...
        }
    }
