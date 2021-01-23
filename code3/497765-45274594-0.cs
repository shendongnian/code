            var loginModel = new LoginModel();
            loginModel.DatabaseName = "TestDB";
            loginModel.UserGroupCode = "G1";
            loginModel.UserName = "test1";
            loginModel.Password = "123";
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("/Connect?", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(loginModel);
            var response = client.Execute(request);
            var obj = JObject.Parse(response.Content);
            LoginResult result = new LoginResult
            {
                Status = obj["Status"].ToString(),
                Authority = response.ResponseUri.Authority,
                SessionID = obj["SessionID"].ToString()
            };
