    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            struct S { public string s; } 
            static void Main(string[] args)
            {
                S instance = new S();
                instance.s = "foo";
                S instance1;
                instance1.s = "foo";
            }
        }
    }
