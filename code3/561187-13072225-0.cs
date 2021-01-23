    public class A
    {
        public B<A> Child { get; set; }
    }
    
    public class B<T>
    {
        public T Parent { get; set; }
    }
    A a = new A();
    a.Child = new B<A>();
    a.Child.Parent = a;
    
    Type parentType = a.Child.Parent.GetType();
