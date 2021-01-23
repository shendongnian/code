    public async List<int> TestGetMethod()
        {
            return await GetIdList(); // await will unwrap the List<int>
        }
    
    
        async Task<List<int>> GetIdList()
        {
            using (HttpClient proxy = new HttpClient())
            {
                string response = await proxy.GetStringAsync("www.test.com");
                List<int> idList = JsonConvert.DeserializeObject<List<int>>();
                return idList;
            }
     }
