    public class EntryPointAttribute : System.Attribute
    {
        public string EntryPoint { get; private set; }
        public EntryPointAttribute(string entryPoint) { this.EntryPoint = entryPoint; }
    }
    public static class EntryPointProcessor
    {
        public static void Process(object theObject)
        {
            Type t = theObject.GetType();
            var ep = t.GetCustomAttributes(typeof(EntryPointAttribute), true).FirstOrDefault();
            string entryPointName = ((EntryPointAttribute)ep).EntryPoint;
            MethodInfo mi = t.GetMethod(entryPointName, BindingFlags.Static | BindingFlags.NonPublic);
            mi.Invoke(null, new object[0] { });
        }
    }
    [EntryPoint("anentrypoint")]
    public class entryPointClass
    {
        private static void anentrypoint()
        {
            Console.WriteLine("in anentrypoint");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            EntryPointProcessor.Process(new entryPointClass());
        }
    }
