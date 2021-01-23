    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Solution
    {
        public class Program
        {
     static void Main(string[] args)
            {
                DirSearch(@"YOUR PATH");
                Console.ReadKey();
            }
    
            static void DirSearch(string dir)
            {
                try
                {
                    foreach (string f in Directory.GetFiles(dir))
                        Console.WriteLine(f);
                    foreach (string d in Directory.GetDirectories(dir))
                    {
                        Console.WriteLine(d);
                        DirSearch(d);
                    }
    
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
