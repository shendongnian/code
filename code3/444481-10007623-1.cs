    namespace PerfTest
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Diagnostics;
        using System.Threading.Tasks;
        class Program
        {
            static void Main(string[] args)
            {
                Stopwatch watch = new Stopwatch();
                for (int i = 2; i < 20; i=i + 2)
                {
                    watch.Start();
                    Parallel.For(0, i, j => { StressTest(); });
                    watch.Stop();
                    Console.WriteLine(watch.ElapsedMilliseconds);
                    
                }
               
                Console.ReadLine();
            }
    
            private static void StressTest()
            {
                //Stopwatch watch = new Stopwatch();
                //watch.Start();
                List<byte> list1 = new List<byte>();
                List<byte> list2 = new List<byte>();
                List<byte> list3 = new List<byte>();
    
    
                int Size1 = 10000000;
                int Size2 = 2 * Size1;
                int Size3 = Size1;
    
                
                for (int i = 0; i < Size1; i++)
                {
                    list1.Add(57);
                }
    
                for (int i = 0; i < Size2; i = i + 2)
                {
                    list2.Add(56);
                }
    
                for (int i = 0; i < Size3; i++)
                {
                    byte temp = list1.ElementAt(i);
                    byte temp2 = list2.ElementAt(i);
                    list3.Add(temp);
                    list2[i] = temp;
                    list1[i] = temp2;
                }
    
                GC.Collect(0,GCCollectionMode.Optimized);
            }
        }
    }
