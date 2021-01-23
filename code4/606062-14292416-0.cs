    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static string[] arr = new string[] { "1", "2", "3" };
            static string[] arr2 = new string[] { "1111", "2222222", "2222222222222222222222" };
    
            [MTAThread]
            public static void Main()
            {
                ThreadStart[] funcs = Enumerable.Range(0, Environment.ProcessorCount * 4).Select(i => new ThreadStart(MutateArray)).ToArray();
                foreach (var func in funcs)
                    new Thread(func).Start();
                Console.ReadLine();
            }
    
            static void MutateArray()
            {
                Random rand = new Random();
                while (true)
                {
                    int i = rand.Next(arr.Length);
                    // swap array contents with contents from another array so arr will always
                    // contain a mixture of arr and arr2 without knowing at which point of time which contents
                    // are inside it.
                    lock (arr)
                    {
                        string tmp = arr[i];
                        arr[i] = arr2[i];
                        arr2[i] = tmp;
                    }
    
                    Do(arr); 
    
                }
            }
    
            static void Do(string[] g)
            {
                AllocateBufferWithRightLength(g, StrLen(g));
            }
    
            static void AllocateBufferWithRightLength(string[] g, int strLen)
            {
                int newLen = StrLen(g);
                if (strLen != newLen)
                {
                    throw new Exception("Invariant broken");
                }
            }
    
            static int StrLen(string[] g)
            {
                int strLen = 0;
                foreach (var str in g)
                {
                    if (str != null)
                        strLen += str.Length;
                }
                Thread.Sleep(1);
                return strLen;
            }
    
    
    
        }
    }
