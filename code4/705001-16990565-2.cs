        using System;
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
                async Task<List<string>[]>  RunAsync()
                {
                    return await Task.WhenAll
                    (
                        Task.Factory.StartNew(() => 
                            new List<string> {Worker1(new Data("One"))}),
                        Task.Factory.StartNew(() => 
                            Worker2(new Data("Two"))),
                        Task.Factory.StartNew(() => 
                            Worker3(new Data("Three")))
                    );
                }
                void Run()
                {
                    var results = RunAsync().Result;
                    // Now results is an array of List<string>, so we can iterate the results.
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
                                                                              
                                                                              
