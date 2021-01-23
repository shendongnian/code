    public static class AssemblyExtensions
    {
        public static string GetDescription(this Assembly assembly)
        {
            var attribute = assembly.GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false)
                .Select(a => a as AssemblyDescriptionAttribute).FirstOrDefault();
            if (attribute == null)
            {
                return String.Empty;
            }
            return attribute.Description;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine(assembly.GetDescription());
            Console.ReadKey();
        }
    }
