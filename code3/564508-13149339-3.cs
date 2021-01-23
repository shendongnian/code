    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
    
            static IEnumerable<char> list_of_is = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g'};
            static IEnumerable<char> list_of_js = new char[] { 'x', 'y', 'z' };
    
            static void Main(string[] args)
            {
                foreach (string result in Randomize())
                    Debug.Write(result);
            }
    
            public static IEnumerable<String> Randomize()
            {
                char[] random_is = list_of_is.ToArray();
                int jCount = list_of_js.Count();
    
                Random r = new Random();
    
                // foreach j
                foreach(char j in list_of_js)
                {
                    // create a random ordering of is
                    for (int i = random_is.Length - 1; i >= 0; i--)
                    {
                        int x = r.Next(0, i);
    
                        // swap
                        char temp = random_is[x];
                        random_is[x] = random_is[i];
                        random_is[i] = temp;
                    }
    
                    // now evaluate the random pairs
                    foreach(Char i in random_is)
                        yield return String.Format("{0}{1} ", Char.ToUpper(i), j);
                }
            }
        }
    }
