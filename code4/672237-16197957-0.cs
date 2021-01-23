        public void Login()
        {
            client = new RestClient("https://api.cloud.appcelerator.com");
            client.CookieContainer = new System.Net.CookieContainer();
            request = new RestRequest("/v1/users/login.json?key={appkey}", Method.POST)
            {
                RequestFormat = DataFormat.Json,
            };
            request.AddUrlSegment("appkey", "key");
            request.AddBody(new
            {
                login = "user",
                password = "pass"
            });
            var response = client.Execute(request);
            SendPush();
        }
