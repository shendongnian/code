    public async Task<object> TestMethod(TestModel model)
        {
            try
            {
                var apicallObject = new
                {
                    Id= model.Id,
                    name= model.Name
                };
                if (apicallObject != null)
                {
                    var bodyContent = JsonConvert.SerializeObject(apicallObject);
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(bodyContent.ToString(), Encoding.UTF8, "application/json");
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        client.DefaultRequestHeaders.Add("access-token", _token); // _token = access token
                        var response = await client.PostAsync(_url, content); // _url =api endpoint url
                        if (response != null)
                        {
                            var jsonString = await response.Content.ReadAsStringAsync();
                            try
                            {
                                var result = JsonConvert.DeserializeObject<TestModel2>(jsonString); // TestModel2 = deserialize object
                            }
                            catch (Exception e){
                                //msg
                                throw e;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
