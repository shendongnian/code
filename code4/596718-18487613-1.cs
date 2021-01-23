    WebResponse Response; 
    HttpWebRequest Request;
    Uri url = new Uri("http://thewebpage.com:port/login/");
    
    CookieContainer cookieContainer = new CookieContainer();
    
    Request = (HttpWebRequest)WebRequest.Create(url);
    Request.Method = "GET";
    Request.CookieContainer = cookieContainer;
    
    // Get the first response to obtain the cookie where you will find the "csrfmiddlewaretoken" value
    Response = Request.GetResponse(); 
    
    string Parametros = "csrfmiddlewaretoken=" + cookieContainer.GetCookies(url)["csrftoken"].Value + "&username=USER&password=PASSWORD&next="; // This whill set the correct url to access
    
    Request = (HttpWebRequest)WebRequest.Create(url); // it is important to use the same url used for the first request
    Request.Method = "POST";
    Request.ContentType = "application/x-www-form-urlencoded";
    Request.UserAgent = "Other";
    // Place the cookie container to obtain the new cookies for further access
    Request.CookieContainer = cookieContainer;
    Request.Headers.Add("Cookie",Response.Headers.Get("Set-Cookie")); // This is the most important step, you have to place the cookies at the header (without this line you will get the 403 Forbidden exception                                                   
    
    byte[] byteArray = Encoding.UTF8.GetBytes(Parametros);
    Request.ContentLength = byteArray.Length;
    
    Stream dataStream = Request.GetRequestStream();
    dataStream.Responseite(byteArray, 0, byteArray.Length);
    dataStream.Close();
    
    Response = Request.GetResponse();
 
   
