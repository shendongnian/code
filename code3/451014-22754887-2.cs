    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
               int a;
               int b;
               int c;
    
               Console.WriteLine("Enter value of 'a':");
               a = Convert.ToInt32(Console.ReadLine());
    
               Console.WriteLine("Enter value of 'b':");
               b = Convert.ToInt32(Console.ReadLine());
    
               Func<int, int, int> funcAdd = (x, y) => x + y;
               c=funcAdd.Invoke(a, b);
               Console.WriteLine(Convert.ToString(c));
    
            }
    
         }
    }
