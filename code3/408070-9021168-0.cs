    class Program
    {
        public string mStringType = null;
        static void Main(string[] args)
        {
            var program = new Program();
            try
            {
                var field = program.GetType().GetField("mStringType");
                Console.WriteLine("Field '{0}' is of type '{1}' and has value '{2}'.", field.Name, field.FieldType.FullName, field.GetValue(program));
                program.mStringType = "Some Value";
                Console.WriteLine("Field '{0}' is of type '{1}' and has value '{2}'.", field.Name, field.FieldType.FullName, field.GetValue(program));
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error");
            }
            Console.ReadKey();
        }
    }
