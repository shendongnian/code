    public class CustomException: Exception
    {
         public CustomException(string message)
            : base(message) { }
    
    }
// 
    if(something == anything)
    {
       throw new CustomException(" custom text message");
    }
