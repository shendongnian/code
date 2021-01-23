    public static IEnumerable<Donut> GetDonutsSince(DateTime dt) {
        HttpClient api = new HttpClient { BaseAddress = new Uri("http://localhost:55174/api/") };
        api.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        String url = "Donut/since?datetime=" + dt;
        HttpResponseMessage response = api.GetAsync(url).Result;
        String responseContent = response.Content.ReadAsStringAsync().Result;
        
        IEnumerable<Donut> events = JsonConvert.DeserializeObject<IEnumerable<Donut>>(responseContent);
        
        return donuts;
    }
