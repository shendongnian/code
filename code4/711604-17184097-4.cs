    public static void Main()
    {
      var login = "www.mywebsite.com/login";
      var loginQuery = "username=username&password=password";
      var client = new CookieAwareWebClient();
      var nvc = HttpUtility.ParseQueryString(loginQuery);
      client.Login(login, nvc);
    }
