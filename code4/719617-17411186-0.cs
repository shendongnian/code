    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ClassLibrary1
    {
        public class Class1
        {
            private static Class1 instance = null;
            private Class1()
            {
            }
            public static Class1 Instance
            {
                get
                {
                    if (null == instance)
                    {
                        instance = new Class1();
                    }
    
                    return instance;
                }
            }
            public string Foo()
            {
                return "HI THERE";
            }
        }
    }
