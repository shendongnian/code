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
    
         public ClientResult<T> ToClientResult<T>()
         {
             //Need to call the parent class implementation and convert result to  generic ver
             var clientResult = new ClientResult<T>();
             SetupClientResult(clientResult);
             clientResult.details = someTvalue;
             return clientResult;
         }
    }
