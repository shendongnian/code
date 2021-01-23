    class Program
    {
        static void Main(string[] args)
        {
            var myobj = new MyClass();
            var method = typeof(MyClass).GetMethod("Init");
            // Call Init<Orders>
            method.MakeGenericMethod(typeof(Orders))
                  .Invoke(myobj, new object[] { "tableOrders" });
            // Call Init<string>
            method.MakeGenericMethod(typeof(string))
                  .Invoke(myobj, new object[] { "tableString" });
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
