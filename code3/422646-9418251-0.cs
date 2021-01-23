    public interface IFoo {
        string Name { get; }
    }
    
    class FooImplementation : IFoo {
        public string Name { get; set; }
    }
    
    public class FooWorker {
        public void WorkOnFoo(IFoo foo) {
            if (null == foo) throw new ArgumentNullException("foo");
            Console.WriteLine(foo.Name);
        }
    }
    public class Program {
        public void Main() {
            IFoo foo = new FooImplementation { Name = "Foo" };
            new FooWorker().WorkOnFoo(foo);
        }
    }
