    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace CS_11_project_Euler_problem_4
    {
    
    class Program
    {
    
        static void Main(string[] args)
        {
            int x, y;
            string product="" , res="";
    
            for (x = 100; x <= 999; x++)
            {
                for (y = 100; y <= 999; y++)
                {
                    product = Convert.ToString(x*y);
    
                    if (product == new String(product.Reverse().ToArray()))
                    {
                        Console.WriteLine("X=" + x + " Y=" + y );
                        
                        if(x*y>Convert.ToInt64(res))
                            res = product;
                            Console.WriteLine("Polindrome is: " + res);
                    }
    
                    else { continue; }
                }
            }
        }
    }
    }
