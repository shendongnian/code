    public static void Main()
    {
      var loginAddress = "www.mywebsite.com/login";
      var loginData = new NameValueCollection
        {
          { "username", "shimmy" },
          { "password", "mypassword" }
        };
      var client = new CookieAwareWebClient();
      client.Login(loginAddress, loginData);
    }
