    class Test
    {
        public int MyProperty { get; set; }
        public int SomeOther { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            object obj = new Test();
            if (obj as Test != null)
            {
                Console.WriteLine("test1");
            }
            if (obj is Test)
            {
                Console.WriteLine("test2");
            }
            
        }
