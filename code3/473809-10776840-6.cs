    using Libraries;
    
    namespace MyApp
    {
      public class AnyClass
      {
        public StringsInterface StringsHelper = StringsClass.getInstance().LowercaseCopy(Example);
      
        public void AnyMethod()
        {
    	  string Example = "HELLO EARTH";
    	  string AnotherExample = StringsHelper;
        } // void AnyMethod(...)  
    	
      } // class AnyClass
      
    } // namespace MyApp
