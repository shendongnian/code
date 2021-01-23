    public class ErrorModel{
        public bool Success{get;set;}
        public string Reason{get;set;}
    }
    
    public JsonResult Upload(HttpPostedFileBase fileData, FormCollection forms)
     {
        var model = new ErrorModel { Success = false };
        try
     {                
        if (fileData.ContentLength > 0)
      {
         var statusCode = Helper.UploadList();
        if (statusCode.Equals(System.Net.HttpStatusCode.Created))
        model.Reason = "File uploaded: " + filename;
        model.Success = true;
        return JSon(model);                           
       } else {
         model.REason = "ERROR: failed to upload file";
         return JSon(model);  
       }                  
     }
       
       }
        catch (Exception ex)
      {  
     model.reason = ex.Message;
     return JSon(model);  
    }   
