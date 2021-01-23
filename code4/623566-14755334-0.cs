    class Program
    {
        [Obsolete]
        public void SomeFunction()
        {
        }
        public static void Main()
        {
            // To read an attribute, you just need the type metadata, 
            // which we can get one of two ways.
            Type typedata1 = typeof(Program);       // This is determined at compile time.
            Type typedata2 = new Program().GetType(); // This is determined at runtime
            // Now we just scan for attributes (this gets attributes on the class 'Program')
            IEnumerable<Attribute> attributesOnProgram = typedata1.GetCustomAttributes();
            // To get attributes on a method we do (This gets attributes on the function 'SomeFunction')
            IEnumerable<Attribute> methodAttributes = typedata1.GetMethod("SomeFunction").GetCustomAttributes();
        }
    }
