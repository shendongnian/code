    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication16
    {
        class Program
        {
            static IEnumerable<int> Func()
            {
                yield return 1;
                yield return 2;
                yield return 3;
            }
            static List<int> MakeList()
            {
                return (List<int>)Activator.CreateInstance(typeof(List<int>), Func());
            }
            static void Main(string[] args)
            {
                foreach(int i in MakeList())
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
