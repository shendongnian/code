    interface IFoo
    {
        public int M(int x, int y);
    }
    public class Foo : IFoo
    {
        public int M(int y, int x)
        {
            return x - y;
        }
    }
    ...
    Foo foo = new Foo();
    IFoo ifoo = foo;
    Console.WriteLine(foo.M(x: 10, y: 3)); // Prints 7
    Console.WriteLine(ifoo.M(x: 10, y: 3)); // Prints -7
