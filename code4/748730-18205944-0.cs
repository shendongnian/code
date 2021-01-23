    public static async Task<MyModel> CreateInstance()
    {
        string googleSearchText;
        using (HttpClient client = new HttpClient())
        {
            using (HttpResponseMessage response = await client.GetAsync(...))
            {
                googleSearchText = await response.Content.ReadAsStringAsync();
            }
        }
        // Synchronous constructor to do the rest...
        return new MyModel(googleSearchText);
    }
