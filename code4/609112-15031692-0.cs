    using System;
    internal interface IFoo
    {
        void Bar();
    }
    internal class Fizz : IFoo, IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Fizz.Dispose");
        }
        public void Bar()
        {
            Console.WriteLine("Fizz.Bar");
        }
    }
    internal class Buzz : IFoo
    {
        public void Bar()
        {
            Console.WriteLine("Buzz.Bar");
        }
    }
    internal static class Factory
    {
        public static IFoo Create(string type)
        {
            switch (type)
            {
                case "fizz":
                    return new Fizz();
                case "buzz":
                    return new Buzz();
            }
            return null;
        }
    }
    public class Program
    {
        
        public static void Main(string[] args)
        {
            IFoo fizz = Factory.Create("fizz");
            IFoo buzz = Factory.Create("buzz");
            using (fizz as IDisposable)
            {
                fizz.Bar();
            }
            using (buzz as IDisposable)
            {
                buzz.Bar();
            }
            Console.ReadLine();
        }
    }
