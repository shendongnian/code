    public string StoreEmail(string l_strEmail)
        {
            string l_strApiResponse = "";
            try
            {
                using (var client = new HttpClient())
                {
                    string l_strJson = "{'email':'" + l_strEmail + "'}";
                    var l_oJson = JObject.Parse(l_strJson);
                    client.BaseAddress = new Uri("http://170.0.0.0:8000/");
                    var response = client.PostAsJsonAsync("http://170.0.0.0:8000/user/testApi/", l_oJson).Result;
                    Task<string> responseString = response.Content.ReadAsStringAsync();
                    l_strApiResponse = responseString.Result;
                }
            }
            catch (Exception ex)
            {
            }
            return l_strApiResponse;
        }
