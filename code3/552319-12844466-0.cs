        public static void Test<T>(T obj)
        {
            if (obj == null) // default refernce type (which is null)
            {
                Console.WriteLine("default!");
            }
            else if(obj.Equals(default(T))) // default value types
            {
                Console.WriteLine("default!");
            }
        }
        public static void Main()
        {
            object o = null;
            Test(o); // test detects default
            Test(0); // test detects default
            Class1 c = new Class1();
            Test(c); // test does not detect default
        }
