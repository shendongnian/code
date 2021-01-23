    using System.Reflection;
    
    namespace A2 {
        public class A2Class {
            public static Assembly GetAssembly() {
                return A1.A1Class.GetAssembly();
            }
        }
    }
