    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
     public static AjaxResult<string> GetAutoCompleteHtml(string termList)
     {
          const string cSharpErrorMessage = "Unable to generate autocomplete HTML.";
    
          try
          {
                    //some logic
          }
          catch (Exception ex)
          {
                    //some logic to clean up and then throw exception
                    throw new Exception(cSharpErrorMessage);
           }
       }
