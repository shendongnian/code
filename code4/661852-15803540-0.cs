    WebRequest webRequest = WebRequest.Create(url);  
    WebResponse webResponse;
    try 
    {
      webResponse = webRequest.GetResponse();
    }
    catch 
    {
      return 0;
    } 
    return 1;
