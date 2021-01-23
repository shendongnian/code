    public static void Main(string[] args)
    {
      List<string> list = new List<string>();
    
      GetData(data =>
      {
        foreach (var item in data)
        {
          list.Add(item);
          Console.WriteLine(item);
        }
        Console.WriteLine("Done");
      });
      Console.ReadLine();
    }
    
    public static void GetData(Action<IEnumerable<string>> callback)
    {
      WebClient webClient = new WebClient();
      webClient.DownloadStringCompleted += (s, e) =>
        {
          List<string> data = new List<string>();
          for (int i = 0; i < 5; i++)
          {
            data.Add(e.Result);
          }
          callback(e.Error == null ? data : Enumerable.Empty<string>());
        };
    
      webClient.DownloadStringAsync(new Uri("http://www.google.com"));
    }
