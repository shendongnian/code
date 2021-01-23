    [WebService] 
     public class Service : System.Web.Services.WebService 
      { 
      [WebMethod] 
      public string Test(string strMsg) 
      { 
          return strMsg; 
      } 
     }
