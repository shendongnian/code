    public static class Test
    {
        private static Lazy<string> m_Property = new Lazy<string>( ()=>
        {
            Console.WriteLine("Lazy invoked"); 
            return "hi";
        },true);
        public static string Property
        {
            get
            {
                return m_Property.Value;
            }
        }
    }
    
    //....consuming code
    
    var test1 = Test.Property; // first call, lazy is invoked
    var test2 = Test.Property; // cached value is used, delgate not invoked
