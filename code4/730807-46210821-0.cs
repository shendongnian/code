    string userToken = "theusertokentogiveyoumagicalpowers";
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("https://graph.facebook.com");
        HttpResponseMessage response = client.GetAsync($"me?fields=name,email&access_token={userToken}").Result;
        response.EnsureSuccessStatusCode();
        string result = response.Content.ReadAsStringAsync().Result;
        var jsonRes = JsonConvert.DeserializeObject<dynamic>(result);
        var email = jsonRes["email"].ToString();
    }
