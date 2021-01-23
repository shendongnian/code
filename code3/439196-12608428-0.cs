            UserLoginModel user = new UserLoginModel { Login = "username", Password = "password" };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:1066/api/");
            HttpResponseMessage response = client.PostAsync("Authenticate", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<ResultModel>().Result;
            }
            else
            {
                return string.Empty;
            }
