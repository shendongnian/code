    public static async void DoSomeThing()
    {
      List<string> list = new List<string>();
      list = await GetDataAsync();
    
      foreach (var item in list)
      {
        Console.WriteLine(item);
      }
    }
    
    public static async Task<List<string>> GetDataAsync()
    {
      WebClient webClient = new WebClient();
      string result = await webClient.DownloadStringTaskAsync(new Uri("http://www.google.com"));
    
      List<string> data = new List<string>();
      for (int i = 0; i < 5; i++)
      {
        data.Add(result);
      }
      return data;
    }
