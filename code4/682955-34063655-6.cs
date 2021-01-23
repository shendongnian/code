	public static async Task GetUser()
	{
		var oauthToken = "123456789foo";
		var baseUrl = "https://www.facebook.com/company/1234567890/scim/";
		var userName = "foo@bar.com";
		
		using (var client = new HttpClient())
		{
			// Set up client and configure for things like oauthToken which need to go on each request
			client.BaseAddress = new Uri(baseUrl);
			
			// Spoof User-Agent to keep Facebook happy
			client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.86 Safari/537.36");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", oauthToken);
			try
			{
				var response = await client.GetAsync($"Users?filter=userName%20eq%20%22{userName}%22");
				response.EnsureSuccessStatusCode();
				var json = await response.Content.ReadAsStringAsync();
				// This is the part which is using the nuget library I referenced
				var jsonDictionary = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(json);
				var queryResponse = new QueryResponseJsonDeserializingFactory<Core1EnterpriseUser>().Create(jsonDictionary);
				var user = queryResponse.Resources.First();                    
			}
			catch (Exception ex)
			{
				// TODO: handle exception
			}
		}
	}
