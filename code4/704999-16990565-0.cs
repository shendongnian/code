    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Data
        {
            public string Value;
            public Data(string value) { Value = value; }
        }
        class Program
        {
            void Run()
            {
                var results = new ConcurrentBag<List<string>>();
                Parallel.Invoke
                (
                    () => results.Add
                        (
                            new List<string>{ Worker1(new Data("One")) }
                        ),
                    () => results.Add
                        (
                            Worker2(new Data("Two"))
                        ),
                   () => results.Add
                        (
                            Worker3(new Data("Three"))
                        )
                );
                foreach (var result in results)
                {
                    result.Print();
                    Console.WriteLine("--------------");
                }
            }
            string Worker1(Data data)
            {
                Thread.Sleep(1000);
                return data.Value;
            }
            List<string> Worker2(Data data)
            {
                Thread.Sleep(1500);
                return Enumerable.Repeat(data.Value, 2).ToList();
            }
            List<string> Worker3(Data data)
            {
                Thread.Sleep(2000);
                return Enumerable.Repeat(data.Value, 3).ToList();
            }
            static void Main()
            {
                new Program().Run();
            }
        }
        static class DemoUtil
        {
            public static void Print(this object self)
            {
                Console.WriteLine(self);
            }
            public static void Print(this string self)
            {
                Console.WriteLine(self);
            }
            public static void Print<T>(this IEnumerable<T> self)
            {
                foreach (var item in self)
                    Console.WriteLine(item);
            }
        }
    }
                                                                              
