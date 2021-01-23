    public async Task<JiraCookie> GetCookieAsync(string myJsonPass, string JiraCookieEndpointUrl)
    {
    	using (var client = new HttpClient())
            {
            	var response = await client.PostAsync(
                    JiraCookieEndpointUrl,
                    new StringContent(myJsonPass, Encoding.UTF8, "application/json"));
        		var json = response.Content.ReadAsStringAsync().Result;
                    var jiraCookie= JsonConvert.DeserializeObject<JiraCookie>(json);
                    return jArr;
             }
    }
    
    public class JiraCookie
    {
    	public Session session { get; set; }
    }
        
    public class Session
    {
    	public string name { get; set; }
        public string value { get; set; }
    }
