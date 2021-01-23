    void Main()
    {
        B b = new B();
    
        C c = new C(Guid.Empty);
        b.Add<Guid>(Guid.Empty);
    }
    
    public class B
    {
        List<C> cs = new List<C>();
        public void Add<T>(T v) { cs.Add(new C(v)); }
    }
    
    public class C<T>
    {
        public C(T c) 
        { 
            if(c is Guid)
            {
                Console.WriteLine("guid"); }
            }else{
                Console.WriteLine("object");
            }
        }
    }
