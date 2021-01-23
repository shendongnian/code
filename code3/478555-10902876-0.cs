    class Program
    {
        public static string GetPropValue(String name, Object obj)
        {
            Type type = obj.GetType();
            System.Reflection.PropertyInfo info = type.GetProperty(name);
            if (info == null) { return null; }
            obj = info.GetValue(obj, null);
            return obj.ToString();
        }
        static void Main(string[] args)
        {
            var dt = GetPropValue("DtProp", new { DtProp = (DateTime?) DateTime.Now});
            Console.WriteLine(dt);
        }
    }
