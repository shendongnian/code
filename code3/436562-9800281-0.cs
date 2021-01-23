    using System.Linq.Xml;
    using System.Net;
    using System.Collections.Generic;
    using System.Web;
    
    // ...
    var client = new WebClient();
    var parameters = new Dictionary<string, string> 
    { 
      { "username", username },
      { "password", password }
    };
    var result = client.UploadString(String.Format("{0}/services/auth/login", BaseUrl), UrlEncode(parameters));
    var doc = XDocument.Load(result);  // load response into XML document (LINQ)
    var key = doc.Elements("sessionKey").Single().Value // get the one-and-only <sessionKey> element.
    Console.WriteLine("====>sessionkey:  {0}  <====", key);
    // ...
    
    // Utility function: 
    private static string UrlEncode(IDictionary<string, string> parameters)
    {
      var sb = new StringBuilder();
      foreach(var val in parameters) 
      {
        // add each parameter to the query string, url-encoding the value.
        sb.AppendFormat("{0}={1}&", val.Key, HttpUtility.UrlEncode(val.Value));
      }
      sb.Remove(sb.Length - 1, 1); // remove last '&'
      return sb.ToString();
    }
