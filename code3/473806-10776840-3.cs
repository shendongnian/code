    namespace Libraries
    {
      public class StringsClass
      {
        private static Singleton instance = null;
     
        private Singleton()
    	{
    	  // ...
    	}
     
        public static synchronized Singleton getInstance()
    	{
            if (instance == null) {
                instance = new Singleton();
            }
            return instance;
        }
    
        public string UppercaseCopy(string Value)
        {
          string Result = "";
    	  
    	  // code where "Value" is converted to uppercase,
    	  // and output stored in "Result"
      	
      	return Result;
        } // string UppercaseCopy(...)
      
        public string LowercaseCopy(string Value)
        {
          string Result = "";
      	
    	  // code where "Value" is converted to lowercase,
    	  // and output stored in "Result"
      	
          return Result;
        } // string LowercaseCopy(...)
      
        public string ReverseCopy(string Value)
        {
          string Result = "";
      	
    	  // code where "Value" is reversed,
    	  // and output stored in "Result"
    	  
    	  return Result;
        } // string ReverseCopy(...)  
    	
      } // class StringsClass
      
    } // namespace Libraries
