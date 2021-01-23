        public async Task<ActionResult> Index()
    {
    
                const string uri = "https://testdoamin.zendesk.com/api/v2/users.json?role[]=agent";
                using (var client1 = new HttpClient())
                {
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes("test@gmail.com:123456")));///username:password for auth
                    client1.DefaultRequestHeaders.Authorization = header;
                   var aa = JsonConvert.DeserializeObject<dynamic>(await client1.GetStringAsync(uri));
                   
                }
    }
