    public MyModel() 
    {
    }
    public async Task Init()
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync("https://api.vkontakte.ru/method/video.get?uid=219171498&access_token=d61b93dfded2a37dfcfa63779efdb149653292636cac442e53dae9ba6a049a75637143e318cc79e826149");
        string googleSearchText = await response.Content.ReadAsStringAsync();
        JObject googleSearch = JObject.Parse(googleSearchText);
        IList<JToken> results = googleSearch["response"].Children().Skip(1).ToList();
        IList<MainPage1> searchResults = new List<MainPage1>();
        foreach (JToken result in results)
        {
            MainPage1 searchResult = JsonConvert.DeserializeObject<MainPage1>(result.ToString());
            searchResults.Add(searchResult);
        }
    }
