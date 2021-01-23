    using System;
    using System.Reflection;
    using A1;
    
    namespace A2
    {
        public class A2Class
        {
            public static Assembly GetAssembly()
            {
                return A1Class.GetAssembly();
            }
        }
    }
