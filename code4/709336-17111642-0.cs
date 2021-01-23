    static class Program
    {
        private static void Main(string[] args)
        {
            var list = new List<Pet>();
            var eList = Expression.Constant(list);
            var pe = Expression.Parameter(typeof(Pet), "p");
            var method = typeof(Program).GetMethod("CreateObject", BindingFlags.Static | BindingFlags.NonPublic);
            var properties = typeof(Pet).GetProperties().Where(pi => pi.Name == "Name"); //will be defined by user
            var selectorBody = Expression.Call(method, Expression.Constant(properties));
            var selector = Expression.Lambda(selectorBody, pe);
            var res = Expression.Call(typeof(Enumerable), "Select", new[] { typeof(Pet), CreateType(properties) }, eList, selector);
        }
        private static Type CreateType(IEnumerable<PropertyInfo> properties)
        {
            return typeof (DynamicType);
        }
        private static object CreateObject(IEnumerable<PropertyInfo> properties)
        {
            var type = CreateType(properties);
            return  Activator.CreateInstance(type);
        }
        class Pet
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        class DynamicType
        {
            public string Name { get; set; }
        }
    }
