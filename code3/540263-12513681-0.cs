    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            Test1 t1 = new Test1();
            string result = ObjToString<Test1>(t1);
            Console.WriteLine(result);
            Console.ReadKey();
        }
        public static string ObjToString<T>(T obj)
        {
            if (obj == null)
            {
                throw new Exception("passed in parameter is null");
            }
            StringBuilder sb = new StringBuilder();
            Type t = obj.GetType();
            PropertyInfo[] properties = t.GetProperties();
            foreach (var property in properties)
            {
                sb.Append(property.Name);
                sb.Append(",");
            }
            return sb.ToString();
        }
    }
    public struct Test1
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
    }
