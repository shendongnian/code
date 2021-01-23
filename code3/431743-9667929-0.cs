    [System.Web.Script.Services.ScriptService]
    [System.Web.Script.Services.GenerateScriptType(typeof(searchResult))]
    public class SearchService : WebService
    {
      [WebMethod]
      public searchResult[] Search(string txtSearch)
      {
         // ...
      }
    }
