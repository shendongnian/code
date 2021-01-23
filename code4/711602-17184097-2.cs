    public static void Main()
    {
      var container = Login();
      var client = new CookieAwareWebClient(container);
      //Download data using client
    }
