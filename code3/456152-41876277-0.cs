    Task<HttpResponseMessage> response = httpClient.PostAsJsonAsync(
                           strMyHttpPostURL,
                           new MyComplexObject { Param1 = param1, Param2 = param2}).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                        //debug:
                        //String s = response.Result.Content.ReadAsStringAsync().Result;
                        MyOtherComplexType moct = (MyOtherComplexType)JsonConvert.DeserializeObject(response.Result.Content.ReadAsStringAsync().Result, typeof(MyOtherComplexType));
