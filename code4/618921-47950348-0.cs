    using (HttpClient httpClient = new HttpClient())
    {
       Dictionary<string, string> tokenDetails = null;
       var messageDetails = new Message { Id = 4, Message1 = des };
       HttpClient client = new HttpClient();
       client.BaseAddress = new Uri("http://localhost:3774/");
       var login = new Dictionary<string, string>
    	   {
    		   {"grant_type", "password"},
    		   {"username", "sa@role.com"},
    		   {"password", "lopzwsx@23"},
    	   };
       var response = client.PostAsync("Token", new FormUrlEncodedContent(login)).Result;
       if (response.IsSuccessStatusCode)
       {
    	  tokenDetails = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content.ReadAsStringAsync().Result);
    	  if (tokenDetails != null && tokenDetails.Any())
    	  {
    		 var tokenNo = tokenDetails.FirstOrDefault().Value;
    		 client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenNo);
    		 client.PostAsJsonAsync("api/menu", messageDetails)
    			 .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
    	  }
       }
    }
