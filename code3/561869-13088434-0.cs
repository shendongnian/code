    class Program
    {
        static void Main(string[] args)
        {
            var fields = typeof(Person).GetFields(BindingFlags.DeclaredOnly 
                                                | BindingFlags.NonPublic 
                                                | BindingFlags.Instance);
            foreach (var fieldInfo in 
                fields.Where(fieldInfo => fieldInfo.FieldType == typeof(List<int>)))
            {
                Console.WriteLine(fieldInfo.ToString());
            }
        }
    }
