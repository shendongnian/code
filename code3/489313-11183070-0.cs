    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Proj5
    {
    class Program
    {
        static void Main(int i)
        {
            for (int i = 0; i < 101; i++)
            {
                Console.WriteLine(TheMethod(i));
            }
        }
    
        string TheMethod(int i)
        {
            string f = "Fizz";
            string b = "Buzz";
    
            if ((i % 3 == 0) && (i % 5 == 0))
            {
                return f+b;
            }
            if (i % 3 == 0)
            {
                return f;
            }
    
            if (i % 5 == 0)
            {
                return b;
            }
            else
            {
                return i.ToString();
            }
    
        }
    }
    }
