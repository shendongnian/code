    class MyClass
    {
        public MyClass(int id, string name, DateTime startDate)
        {
        }
 
        public MyClass(int id, string name, string startDate)
            : this(id, name, DateTime.Parse(startDate))
        {
        }
    }
