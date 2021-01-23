    public async void GetStringFromWebpage()
    {
        using (HttpClient wc = new HttpClient())
        {
          var data = await wc.GetStringAsync("http://google.com/");
          Debug.WriteLine("string:" + data);
        }
    }
