You should pass the credentials to the HttpWebRequest instance using request.Credentials public class CookieAwareWebClient : WebClient
{
  private readonly CookieContainer _cookie = new CookieContainer();
  private string userName;
  private string password;
  public CookieAwareWebClient(string user, string pass) 
  {
    userName = user;
    password = pass; 
  }
  protected override WebRequest GetWebRequest(Uri address)
  {
    WebRequest request = base.GetWebRequest(address);
    if (!string.IsNullOrEmpty(userName)) 
    {
      request.Credentials = new NetworkCredential(userName, password);
    }
    if (request is HttpWebRequest)
    {
      (request as HttpWebRequest).CookieContainer = _cookie;
    }
    
    return request;
  }
}
