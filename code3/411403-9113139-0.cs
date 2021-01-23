        private static void Main(string[] args)
        {
            MyOE zz = new MyOE { ageField = 45 };
            foreach (PropertyInfo property in zz.GetType().GetProperties())
            {
                // Gets the first attribute of type ColumnAttribute for the property
                // As you defined AllowMultiple as true, you should loop through all attributes instead.
                var attribute = property.GetCustomAttributes(false).OfType<ColumnAttribute>().FirstOrDefault();
                if (attribute != null)
                {
                    Console.WriteLine(attribute.Name);    // Prints AGE_FIELD
                }
            }
            Console.ReadKey();
        }
