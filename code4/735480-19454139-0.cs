    public class MySubClass : MyClass
    {
        int FooValue() // some method
        {
            int baseResult = ((IFoo)this).FooValue(); <-- Can use 'this' like this
            return baseResult * 2;
        }
    }
