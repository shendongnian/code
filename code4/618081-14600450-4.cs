    public class Result
    {
        public string ErrorCode { get; set;}
        public string ErrorMessage { get; set;}
        public boo Success { get; set;}
        //Lots more properties
    
         public ClientResult ToClientResult()
         {
             var clientResult = new ClientResult();
             SetupClientResult(clientResult);
             return clientResult;
         }
         
         protected void SetupClientResult(ClientResult clientResult) 
         {    
             //some pretty involved calculations of error coded and status           
         }
    }
    
    public class Result<T> : Result
    {
         public T details {get; set;}
    
         // This now shadows the original ToClientResult method. The trap here is that if
         // you are treating your Result<T> instance as a Result, this method will not be 
         // called, and the return type will be ClientResult and not ClientResult<T>.
         // See: http://stackoverflow.com/questions/392721/difference-between-shadowing-and-overriding-in-c?lq=1
         public ClientResult<T> ToClientResult()
         {
             var clientResult = new ClientResult<T>();
             SetupClientResult(clientResult);
             clientResult.SomeProperty = details;
             return clientResult;
         }
    }
