    class C
    {
    }
    class A : C
    {
    }
    class B : C
    {
    }
    static class Extender
    {
        public static void M(this B b)
        {
            Console.WriteLine(" Extension method on B");
        }
        public static void M(this A a)
        {
            Console.WriteLine(" Extension method on A");
        }
    }
    static void Main(string[] args)
        {
            C c = new A();// The actual instance here will be created using some factory.
            object instance = Activator.CreateInstance(c.GetType());
            Type typeToFind = c.GetType();
            Type typeToQuery = typeof(Extender);
            var query = from method in typeToQuery.GetMethods(BindingFlags.Static
                            | BindingFlags.Public | BindingFlags.NonPublic)
                        where method.IsDefined(typeof(ExtensionAttribute), false)
                        where method.GetParameters()[0].ParameterType == typeToFind
                        select method;
          // You would be invoking the method based on its name. This is just a quick demo. 
            foreach (MethodInfo m in query)
            {
                m.Invoke(instance, new object[] { instance });
            }
        }
