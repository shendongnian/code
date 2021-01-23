    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            ABDto abDto = new ABDto(a, b);
    
        }
    
    
    }
    
    public class A
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
    }
    
    public class B
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
    }
    
    public class ABDto
    {
        public Int32 Id { get; set; }
    
        public String AName { get; set; }
    
        public String BName { get; set; }
    
        public ABDto(A a, B b)
        {
            AName = a.Name;
            BName = b.Name;
        }
    }
