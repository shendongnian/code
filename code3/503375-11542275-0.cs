    // preparation of the dictionary to map your sub domain to the clients website
    IDictionary<String, String> clientRedirect = new Dictionary<String, String>();
    clientRedirect.Add("john", "www.johnswebsite.com");
    
    ...
    
    // actual processing incoming request
    String strToRedirect = @"john.mywebsite.com/categories-150.html";
    String relPath = strToRedirect.Substring(strToRedirect.IndexOf(@"/")); // = "/categories-150.html"
    String subdomain = strToRedirect.Substring(0, strToRedirect.IndexOf(@"/"));
    subdomain = subdomain.Replace(@".mywebsite.com", ""); // = "john"
    String newUrl = clientRedirect[subdomain] + relPath; // = "www.johnswebsite.com/categories-150.html"
    
    WebRequest request = WebRequest.Create(newURL); // use the URL
