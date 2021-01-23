    class Program
    {
        static void Main(string[] args)
        {
            var myobj = new MyClass();
            // Call MyClass.Init<Orders>
            CallMyClassInit(typeof(Orders), "tableOrders");
            // Call Init<string>
            CallMyClassInit(typeof(string), "tableString");
        }
        static void CallMyClassInit(MyClass obj, Type type, string tableName)
        {
            typeof(MyClass)
                .GetMethod("Init")
                .MakeGenericMethod(type)
                .Invoke(obj, new object[] { tableName });
        }
    }
    class Orders { }
    class MyClass
    {
        public void Init<T>(string tableName)
        {
            Console.WriteLine("I was called with type " + typeof(T) + " for table " + tableName);
        }
    }
