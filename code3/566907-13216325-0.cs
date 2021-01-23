    public class Program
    {
        public static void Main(string[] args)
        {
            bool invokeGeneric = true;
            MyClass<int> b = new MyClass<int>();
            var type = b.GetType().GetGenericTypeDefinition();
            int index = 0;
            foreach(var mi in type.GetMethods().Where(mi => mi.Name == "MyMethod"))
            {
                if (mi.GetParameters()[0].ParameterType.IsGenericParameter == invokeGeneric)
                {
                    break;
                }
                index++;
            }
            
            var method = b.GetType().GetMethods().Where(mi => mi.Name == "MyMethod").ElementAt(index);
            method.Invoke(b, new object[] { 1 });
        }
    }
    
    public class MyClass<T>
    {
        public void MyMethod(T a)
        {
            Console.WriteLine("In generic method");
        }
        
        public void MyMethod(int a)
        {
            Console.WriteLine("In non-generic method");
        }
    }
