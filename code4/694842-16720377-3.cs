    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        public class Mammal {}
        public class Cat: Mammal {}
        public class Pig: Mammal {}
        public class Dog: Mammal {}
        public class Pug:  Dog {}
        public class Manx: Cat {}
        public static class Feeder
        {
            static readonly Dictionary<Type, Action<Mammal>> map = createMap();
            static Dictionary<Type, Action<Mammal>> createMap()
            {
                return new Dictionary<Type, Action<Mammal>>
                {
                    {typeof(Cat),  mammal => GiveFood((Cat)  mammal)},
                    {typeof(Dog),  mammal => GiveFood((Dog)  mammal)},
                    {typeof(Manx), mammal => GiveFood((Manx) mammal)}
                };
            }
            public static void GiveFood(Mammal mammal)
            {
                for (
                    var currentType = mammal.GetType(); 
                    typeof(Mammal).IsAssignableFrom(currentType);
                    currentType = currentType.BaseType)
                {
                    if (map.ContainsKey(currentType))
                    {
                        map[currentType](mammal);
                        return;
                    }
                }
                DefaultGiveFood(mammal);
            }
            public static void DefaultGiveFood(Mammal mammal)
            {
                Console.WriteLine("Feeding an unknown mammal.");
            }
            public static void GiveFood(Cat cat)
            {
                Console.WriteLine("Feeding the cat.");
            }
            public static void GiveFood(Manx cat)
            {
                Console.WriteLine("Feeding the Manx cat.");
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
                feed(new Cat());
                feed(new Manx());
                feed(new Dog());
                feed(new Pug());
                feed(new Pig());
                feed(new Mammal());
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
                                                                              
