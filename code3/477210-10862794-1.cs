    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    
    namespace AccessPrivateField
    {
        class foo
        {
            public foo(string str)
            {
                this.str = str;
            }
            private string str;
            public string Get()
            {
                return this.str;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                foo bar = new foo("hello");
                Console.WriteLine(bar.Get());
                typeof(foo).GetField("str", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(bar, "changed");
                Console.WriteLine(bar.Get());
                //output:
                //hello
                //changed
            }
        }
    }
