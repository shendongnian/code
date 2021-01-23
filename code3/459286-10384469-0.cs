    public class BaseClass
    {
        public void FunctionYouNeed();
    }
    
    public class Derived : BaseClass
    {
        public void OtherFunction();
    }
    
    public class MyGenericClass<T> where T: BaseClass
    {
        public MyGenericClass(T wrappedValue)
        {
            WrappedValue = wrappedValue;
        }
    
        public T WrappedValue { get; set; }
    
        public void Foo()
        {
            WrappedValue.FunctionYouNeed();
        }
    }
    
    ...
    
    var MyGenericClass bar = new MyGenericClass<Derived>(new Derived());
    
    bar.Foo();
    
    bar.WrappedValue.OtherFunction();
