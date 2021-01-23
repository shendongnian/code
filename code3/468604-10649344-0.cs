    public interface ITest
    {
        String Say();
        Int32 DoSomething(Int32 a, Int32 b);
    }
    class Program
    {
        public static void Main()
        {
            var repo = new MockRepository(MockBehavior.Strict);
            var mock = repo.Of<ITest>()
                           .Where(s => s.Say() == "Hi!")
                           .Where(s => s.DoSomething(5, 4) == 20)
                           .Where(s => s.DoSomething(4, 5) == 9)
                           .Where(s => s.DoSomething(It.IsAny<Int32>(), 7) == 99)
                           .First();
            Console.WriteLine(mock.Say());                 // prints Hi!
            Console.WriteLine(mock.DoSomething(5, 4));     // prints 20
            Console.WriteLine(mock.DoSomething(4, 5));     // prints 9
            Console.WriteLine(mock.DoSomething(23423, 7)); // prints 99
            Console.WriteLine(mock.DoSomething(0, 0));     // Fail due to MockBehavior.Strict
            Console.ReadKey();
        }
    }
