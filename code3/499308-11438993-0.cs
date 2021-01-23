    using System;
    public interface IFoo { }
    public abstract class Base { }
    public class Derived : Base, IFoo { }
    public class Arbitrary {
        public Base GetBase() { return new Derived(); }
    }
    public class Arbitrary2 : Arbitrary {
        public IFoo GetDerived() {
            return (IFoo)base.GetBase();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Arbitrary2 test = new Arbitrary2();
            IFoo check = test.GetDerived();
            Console.WriteLine(check.GetType().Name);
            Console.WriteLine("Press key to exit:");
            Console.ReadKey();
        }
    }
