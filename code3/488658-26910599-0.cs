      try {
        var response = new RestClient {
          BaseUrl = "https://theproxisright.com/",
          Proxy = new WebProxy("1.2.3.4", 8080),
          Timeout = 10000
        }.Execute(new RestRequest {
          Resource = "api/Proxy/Get?apiKey=ENTER_FREE_OR_UNLIMITED_API_KEY_HERE",
          Method = Method.GET,
        });
        if (response.ErrorException != null) {
          throw response.ErrorException;
        } else {
          Console.WriteLine(response.Content);
          var wb = new WebBrowser{ Width = 200 };
          webBrowserStack.Children.Add(wb);
          wb.NavigateToString(response.Content);
        }
      } catch (Exception ex) {
        Console.Error.WriteLine(ex.Message);
      }
