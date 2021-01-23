     <input type="button" id="btnClose" value="Close" onclick="DeleteEntryFromSession();"/>
    
    //javascript
    function DeleteEntryFromSession()
    {
            PageMethods.DeleteSessionEntry(para1,function(result)
            {
                //Success
                //your closing code comes here
    
    
            } ,function(error){  //error});
    }
    
    //c#
    [WebMetod]
    public static string DeleteSessionEntry(string para1)
    {
      try
      {
           // HttpContext.Current.Session["sessionName"]; //To Get session 
           //Delete Entry from Session
           return "true"
      }
      catch(Exception)
      {
           throw;
      }
    
    }
