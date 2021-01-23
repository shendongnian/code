    void Main()
    {
    	List<A> IDs= new List<A>() {
        	new A() { ID = "1", Values = new List<B>() {
                                 new B { Code = "1", DisplayName = "1"}, 
                                 new B { Code = "2", DisplayName = "2"},
                                 new B { Code = "3", DisplayName = "3"} } },
     		new A() { ID = "4", Values = new List<B>() { 
    	                         new B { Code = "4", DisplayName = "4"}, 
    	                         new B { Code = "5", DisplayName = "5"},
    	                         new B { Code = "6", DisplayName = "6"} } },
     		new A() { ID = "7", Values = new List<B>() { 
    	                         new B { Code = "7", DisplayName = "7"}, 
    	                         new B { Code = "8", DisplayName = "8"},
    	                         new B { Code = "9", DisplayName = "9"} } }
    	};
    
    	A result = IDs.Where(a => a.Values.Any(b=> b.Code == "4")).FirstOrDefault();
        result.Dump();
    	result = IDs.FirstOrDefault(a => a.Values.Any(b=> b.Code == "8"));
        result.Dump();
      
    }
    
    // Define other methods and classes here
    public class A
    {
        public string ID { get; set; }
        public IList<B> Values { get; set; }
    }
    
    public class B
    {
        public string Code { get; set; }
        public string DisplayName { get; set; }
    }
