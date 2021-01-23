    public class X
    {
        public void Foo()
        {
             Console.WriteLine("Something");
        }
    }
    public class Y : X // y derives from X
    {
        public override void Foo()
        {
             Console.WriteLine("Class Y");
        }
    }
    public class Program
    {
        static void Main()
        {
              X item = new Y(); // covariance.
              item.Foo();   // prints "Class Y"
        }
    }
