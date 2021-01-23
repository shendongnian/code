    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication1 {   
        class Program {   
            static void Main(string[] args) {
                int COUNT = 1000000000;
                String str = "Something";
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();
                for (int i = 0; i < COUNT; i++) {
                    if (str.Equals("")) {
                    }
                }
                Console.WriteLine(sw.ElapsedTicks);
    
                sw = Stopwatch.StartNew();
                sw.Start();
                for (int i = 0; i < COUNT; i++) {
                    if (String.IsNullOrEmpty(str)) {
                    }
                }
                Console.WriteLine(sw.ElapsedTicks);
    
                Console.ReadLine();
            }
        }
    }
