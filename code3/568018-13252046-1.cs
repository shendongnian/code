    class Program
    {
        static void Main(string[] args)
        {
            var b = new B();
            b.Enabled = false;
            b.SomeMethod();
            b.AnotherMethod();
        }
    }
    
    public interface IEnabled
    {
        bool Enabled { get; }
    }
    
    [Modular(AttributeInheritance = MulticastInheritance.Multicast)]
    public class A : IEnabled
    {
        [Modular(AttributeExclude = true)]
        public bool Enabled { get; set; }
    
        public void SomeMethod()
        {
            Console.WriteLine("in SomeMethod");
        }
    }
    
    public class B : A
    {
        public void AnotherMethod()
        {
            Console.WriteLine("in AnotherMethod");
        }
    }
