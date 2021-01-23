    public Task<List<int>> TestGetMethod()
        {
            return GetIdList();
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
