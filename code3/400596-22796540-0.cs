    public class FacebookOAuth
    {
    	private string _loginUrl = "https://www.facebook.com/login.php?login_attempt=1";
    	private string _redirectUrl = "https://www.facebook.com/connect/login_success.html";
    	private string _authorizeUrl = "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}";
    	private string _tokenUrl = "https://graph.facebook.com/oauth/access_token?code={0}&client_id={1}&redirect_uri={2}";
    	private CookieContainer _cookieContainer = new CookieContainer();
    	private string _httpsRefUrl = "https://facebook.com";
    
    	
    	public string Authenticate(UserInfo user)
    	{
    		// get post data
    		var postData = GetPostData(user, _loginUrl);
    		// authentificate        
    		var content = GetContant(_loginUrl, postData);
    		return content;
    	}
    
    	private string GetPostData(UserInfo user, string loginUrl)
    	{
    		// get content from login form
    		var content = GetContant(loginUrl);
    		return GetPostDataFromContent(content, user);
    	}
    
    	private string GetPostDataFromContent(string content, UserInfo user)
    	{	
    		var dictOfPostData = new Dictionary<string, string>();
    		if (!string.IsNullOrEmpty(content))
    		{
    			var doc = XDocument.Parse(content);
    			var inputs = doc.Descendants(XName.Get("input"));
    			foreach (var item in inputs)
    			{
    				var attrbuteName = item.Attributes(XName.Get("name")).FirstOrDefault();
    				var attrbuteValue = item.Attributes(XName.Get("value")).FirstOrDefault();
    				if (attrbuteName != null)
    				{
    					switch (attrbuteName.Value)
    					{
    						case "lsd":
    						case "default_persistent":
    						case "timezone":
    						case "lgnrnd":
    						case "lgnjs":
    						case "locale":
    							dictOfPostData.Add(attrbuteName.Value, attrbuteValue.Value);
    							break;
    						case "email":
    							dictOfPostData.Add(attrbuteName.Value, user.Login);
    							break;
    						case "pass":
    							dictOfPostData.Add(attrbuteName.Value, user.Password);
    							break;
    
    					}
    				}
    			}
    		}
    		return string.Join("&", dictOfPostData.Select(pair => string.Format("{0}={1}", pair.Key, pair.Value))); ;
    	}
    	/// <summary>
    	/// <see cref="GetContant(string, string, Func&lt;HttpWebResponse, string&gt;)"/>
    	/// </summary>
    	/// <param name="url"></param>
    	/// <returns></returns>
    	public string GetContant(string url)
    	{
    		return GetContant(url, string.Empty, null);
    	}
    
    	/// <summary>
    	/// <see cref="GetContant(string, string, Func&lt;HttpWebResponse, string&gt;)"/>
    	/// </summary>
    	/// <param name="url"></param>
    	/// <param name="postData"></param>
    	/// <returns></returns>
    	public string GetContant(string url, string postData)
    	{
    		return GetContant(url, postData, null);
    	}
    
    	/// <summary>
    	/// <see cref="GetContant(string, string, Func&lt;HttpWebResponse, string&gt;)"/>
    	/// </summary>
    	/// <param name="url"></param>
    	/// <param name="funcParseResponse"></param>
    	/// <returns></returns>
    	public string GetContant(string url, Func<HttpWebResponse, string> funcParseResponse)
    	{
    		return GetContant(url, string.Empty, funcParseResponse);
    	}
    
    	/// <summary>
    	/// Get content from web page or write post data
    	/// If post data empty call method=GET, else POST
    	/// </summary>
    	/// <param name="url">Start url</param>
    	/// <param name="postData">Post data, can be null</param>
    	/// <param name="funcParseResponse"></param>
    	/// <returns></returns>
    	public string GetContant(string url, string postData, Func<HttpWebResponse, string> funcParseResponse)
    	{
    		var content = string.Empty;
    		var encoding = Encoding.UTF8;
    		var webRequest = (HttpWebRequest)HttpWebRequest.Create(url);
    
    		if (!string.IsNullOrEmpty(postData))
    		{
    			webRequest.Method = "POST";
    		}
    
    		webRequest.Referer = _httpsRefUrl;
    		webRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/7.0)";
    		webRequest.Accept = "text/html, application/xhtml+xml, */*";
    		webRequest.Headers.Add("Accept-Language", "ru");
    		webRequest.ContentType = "application/x-www-form-urlencoded";
    		webRequest.CookieContainer = _cookieContainer;
    		webRequest.KeepAlive = true;
    		webRequest.AllowAutoRedirect = false;
    
    		if (!string.IsNullOrEmpty(postData))
    		{
    			// Write post data
    			var dataBytes = encoding.GetBytes(postData);
    			webRequest.ContentLength = dataBytes.Length;
    			webRequest.GetRequestStream().Write(dataBytes, 0, dataBytes.Length);
    		};
    
    		// make request
    		using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
    		{
    			using (var stream = webResponse.GetResponseStream())
    			{
    				var streamReader = new StreamReader(stream, encoding);
    				content = streamReader.ReadToEnd();
    			}
    			var parseResult = funcParseResponse != null ? funcParseResponse.Invoke(webResponse) : string.Empty;
    			if (!string.IsNullOrEmpty(parseResult))
    			{
    				return parseResult;
    			}
    			// If we have status 302
    			if (webResponse.StatusCode == HttpStatusCode.Found)
    			{
    				var redirectUrl = Convert.ToString(webResponse.Headers["Location"]);
    				// call handly
    				content = this.GetContant(redirectUrl, funcParseResponse);
    			}
    		}
    		return content;
    	}
    }
    
    public class UserInfo
        {
            public UserInfo(string login, String pwd)
            {
                Login = login;
                Password = pwd;
            }
            public string Login { get; set; }
            public string Password { get; set; }
    		
        }
