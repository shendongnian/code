    internal class Program
    {
        public const string ConstExample = "constant value";
        private static void Main(string[] args)
        {
            FieldInfo[] fieldInfos = typeof(Program).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            var constants = fieldInfos.Where(z => z.IsLiteral && !z.IsInitOnly).ToList();
            foreach (var constant in constants)
            {
                string constantName = constant.Name;
                object constantValue = constant.GetValue(null);
                Console.WriteLine(string.Format("Constante name: {0}, constant value: {1}", constantName, constantValue));
            }
            Console.ReadKey();
        }
    }
