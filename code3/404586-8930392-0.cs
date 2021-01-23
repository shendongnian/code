    public class Result
    {
       public bool Success {get;set;}
       public string AccessToken {get;set;}
       public string ErrorMessage {get;set;}
    }
    
    
    public Result GetFacebookToken()
    {
       Result result = new Result();
    
       try{
          result.AccessToken = "FACEBOOK TOKEN";
          result.Success = true;
       }
       catch(Exception ex){
          ErrorMessage = ex.Message;
          result.Success = false;
       }
    
       return result;
    }
