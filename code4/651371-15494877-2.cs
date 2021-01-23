     static void Main(string[] args)
        {
            List<TestClass> list = new List<TestClass>();
            foreach (TestClass item in list)
            {
                ValueClass x = item.Property;
                int y = item.Property.Id;
            }
        }
