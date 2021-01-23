    public static class Test // this is your ClassB
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
                Console.WriteLine("value request");
                return m_Property.Value;
            }
        }
    }
    
    //....consuming code, this is in your ClassA somewhere
    
	var test1 = Test.Property; // first call, lazy is invoked
	var test2 = Test.Property; // cached value is used, delgate not invoked
	var test3 = Test.Property; // cached value is used, delgate not invoked
	var test4 = Test.Property; // cached value is used, delgate not invoked
	var test5 = Test.Property; // cached value is used, delgate not invoked
