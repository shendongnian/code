    using System;
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main()
            {
            }
        }
        public abstract class Entity
        {
        }
        public abstract class Entity<T> : Entity where T : Entity<T>
        {
            public abstract void DoSomethingWithTheSameTypeAsMe(T item);
        }
        public sealed class Derived1: Entity<Derived1>
        {
            // You are forced to implement DoSomethingWithTheSameTypeAsMe() with a param type "Derived1".
            // (i.e. the parameter is the same type as 'this')
            public override void DoSomethingWithTheSameTypeAsMe(Derived1 item)
            {
                Console.WriteLine("Doing something with a Derived1 item.");
            }
        }
        public sealed class Derived2: Entity<Derived2>
        {
            public override void DoSomethingWithTheSameTypeAsMe(Derived2 item)
            {
                Console.WriteLine("Doing something with a Derived2 item.");
            }
        }
    }
