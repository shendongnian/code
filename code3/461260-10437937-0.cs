    public class example {
       public int prop1 { get; set; } 
     
       public static example Instance {
           var exampleObject = (example)(HttpContext.Current.Session["exampleClass"]
                                         ?? new example());
		   
		   HttpContext.Current.Session["exampleClass"] = exampleObject;
		   
           return exampleObject; 
       } 
     
    }
