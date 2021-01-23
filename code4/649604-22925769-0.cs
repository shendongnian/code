    static private async Task<JToken> 
               ImageUploadApiCallAsync(string strApiName, List<KeyValuePair<string, string>> parameterList, Stream imageStream, string strFileName)
            {
                JToken token = null;
    
                if (!CheckConnection())
                {
                    token = @"{
                                    'success':false,
                                    'message':'No connection',
                                    'errorcode':1
                                    }";
                    return token;
                }
    
                try
                {
                    //Get your api URL
                    string strRequestUri = getApiUrlWithApiName(strApiName);
                    var httpClient = new HttpClient(new HttpClientHandler());
    
                    using (var content = new MultipartFormDataContent())
                    {
                        //I did a stream compression here since I don't want the original size image to upload to my server to reduce space and internet flow.
                        Stream uploadStream = SystemUtil.CompressImageStream(imageStream);
   
                        content.Add(new StreamContent(uploadStream), "file", strFileName);
    
                        //Add my api parameters into content
                        foreach (var keyValuePair in parameterList)
                        {
                            content.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);
                        }
                        //Do PostAsync
                        HttpResponseMessage response = await httpClient.PostAsync(strRequestUri, content);
                        HttpResponseMessage message = response.EnsureSuccessStatusCode();
                        //Get result from server
                        var responseString = await response.Content.ReadAsStringAsync();
    
                        token = JObject.Parse(responseString);
                    }
                }
                catch (Exception e)
                {
                    token = @"{
                                    'success':false,'message':'" + e.Message + "','errorcode':2}";
                }
                return token;
            }
