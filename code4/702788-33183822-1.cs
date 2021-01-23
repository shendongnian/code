    var model = new LoginModel { Username = "patient@gmail.com", Password = "123456", DeviceId = "123456789", RoleId = 1 };
                url.Append("/Login");
                string data = JsonConvert.SerializeObject(model);// "{\"username\":\"dscdemo0@gmail.com\",\"password\":\"vipin123\"}";
                NameValueCollection inputs = new NameValueCollection();
                inputs.Add("json", data);
                WebClient client = new WebClient();
                var reply = client.UploadValues(url.ToString(), inputs);
                string temp = Encoding.ASCII.GetString(reply);
                var result = JsonConvert.DeserializeObject<MessageTemplateModel>
    (temp);
