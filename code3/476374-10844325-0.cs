    public class CustomFilter : FilterAttribute, IAuthorizationFilter
      {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
          var request = filterContext.RequestContext.HttpContext.Request;
    
          var body = request.InputStream;
          var encoding = request.ContentEncoding;
          var reader = new StreamReader(body, encoding);
          var json = reader.ReadToEnd();
    
          var ser = new JavaScriptSerializer();
          
          // you can read the json data from here
          var jsonDictionary = ser.Deserialize<Dictionary<string, string>>(json); 
    
          // i'm resetting the position back to 0, else the value of product in the action  
          // method will  be null.
          request.InputStream.Position = 0; 
        }
      }
