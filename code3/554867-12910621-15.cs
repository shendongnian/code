    using System.Reflection;
    namespace A1 {
        public class A1Class {
            public static Assembly GetAssembly() {
                return Assembly.GetCallingAssembly();
            }
        }
    }
