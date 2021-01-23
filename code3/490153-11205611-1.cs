    interface IUpdatable
    {
        void Update();
    }
    
    
    public abstract class Parent { }
    
    public class A : Parent
    {
        public void Update()
        {
            Console.WriteLine("A.Update");
        }
    }
    
    public class AWrapper : IUpdatable
    {
        public A Inner { get; private set; }
        public AWrapper(A a)
        {
            Inner = a;
        }
    
        public void Update()
        {
            Inner.Update();
        }
    }
