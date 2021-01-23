                using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Collections;
                namespace WindowMaker
                {
                    class Program
                    {
      
                        static void Main(string[] args)
                        {
                            System.Console.WriteLine("Enter Main string...");
                            String str = System.Console.ReadLine();
                            System.Console.WriteLine("Enter sub string...");
                            String sub = System.Console.ReadLine();
                            Boolean flag;
                            int strlen=sub.Length;
                            int inde = str.IndexOf(sub);
                            while (inde != -1)
                            {
                                inde = str.IndexOf(sub);
                                str=str.Replace(sub,"");
                            }
                            System.Console.WriteLine("Remaining string :: {0}",str);
                                Console.Read();
                        }
     
                    }
                }
