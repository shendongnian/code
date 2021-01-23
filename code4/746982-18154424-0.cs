    public class ReturnObject
    {
         public YourModel Model {get;set;}
         public ResultObject ResponseResult {get;set;}
         public int? MessageType {get;set;}
         public string Message {get;set;}
    }
    
    
    string result = eml.PostData("API/Save", dataJSON.ToString());
    var returnresult = new JavaScriptSerializer().Deserialize<ReturnObject>(result);
    {
      if(returnresult.MessageType.HasValue)
      {
         var messageType = returnResult.MessageType.Value;
         etc etc.
      }
      
    } 
