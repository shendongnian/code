    public async void GetData()
    {
        using(HttpClient client = new HttpClient())
        {
            var responseMsg = await client.GetAsync(requesturl);
            responseMsg.EnsureSuccessStatusCode();
            string responseBody = await responseMsg.Content.ReadAsStringAsync();
        }
    }
}
