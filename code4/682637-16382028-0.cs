        static void Main(string[] args)
        {
            FieldInfo field = typeof(TestClass).GetFields(BindingFlags.Instance | BindingFlags.Public)[0];
            Console.WriteLine(Nullable.GetUnderlyingType(field.FieldType).ToString());
            Console.ReadKey();
 
        }
