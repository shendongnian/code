    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        public class Mammal {}
        public class Cat: Mammal {}
        public class Dog: Mammal {}
        public static class Feeder
        {
            static readonly Dictionary<Type, Action<Mammal>> map = createMap();
            static Dictionary<Type, Action<Mammal>> createMap()
            {
                return new Dictionary<Type, Action<Mammal>>
                {
                    {typeof (Cat), mammal => GiveFood((Cat) mammal)},
                    {typeof (Dog), mammal => GiveFood((Dog) mammal)}
                };
            }
            public static void GiveFood(Mammal mammal)
            {
                map[mammal.GetType()](mammal);
            }
        
            public static void GiveFood(Cat cat)
            {
                Console.WriteLine("Feeding the cat.");
            }
            public static void GiveFood(Dog dog)
            {
                Console.WriteLine("Feeding the dog.");
            }
        }
        class Program
        {
            void test()
            {
                Cat cat = new Cat();
                Dog dog = new Dog();
                feed(cat);
                feed(dog);
            }
            void feed(Mammal mammal)
            {
                Feeder.GiveFood(mammal);
            }
            static void Main()
            {
                new Program().test();
            }
        }
    }
