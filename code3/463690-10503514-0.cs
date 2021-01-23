    public class A
    {
        public A()
        { }
        public A(int size)
        { }
    };
    
    class B : public A
    {
        public B() 
        {// this calls base class constructor A() 
        }
        public B(int size) : base(size)
        { // this calls the overloaded constructor A(size)
        }
    }
