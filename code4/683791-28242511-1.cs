    private static void Upload()
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("User-Agent", "CBS Brightcove API Service");
               
            using (var content = new MultipartFormDataContent())
            {
                var path = @"C:\B2BAssetRoot\files\596086\596086.1.mp4";
                string assetName = Path.GetFileName(path);
                var request = new HTTPBrightCoveRequest()
                    {
                        Method = "create_video",
                        Parameters = new Params()
                            {
                                CreateMultipleRenditions = "true",
                                EncodeTo = EncodeTo.Mp4.ToString().ToUpper(),
                                Token = "x8sLalfXacgn-4CzhTBm7uaCxVAPjvKqTf1oXpwLVYYoCkejZUsYtg..",
                                Video = new Video()
                                    {
                                        Name = assetName,
                                        ReferenceId = Guid.NewGuid().ToString(),
                                        ShortDescription = assetName
                                    }
                            }
                    };
                //Content-Disposition: form-data; name="json"
                var stringContent = new StringContent(JsonConvert.SerializeObject(request));
                stringContent.Headers.Add("Content-Disposition", "form-data; name=\"json\"");
                content.Add(stringContent, "json");
                FileStream fs = File.OpenRead(path);
                var streamContent = new StreamContent(fs);
                streamContent.Headers.Add("Content-Type", "application/octet-stream");
                //Content-Disposition: form-data; name="file"; filename="C:\B2BAssetRoot\files\596090\596090.1.mp4";
                streamContent.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\"" + Path.GetFileName(path) + "\"");
                content.Add(streamContent, "file", Path.GetFileName(path));
                   
                //content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                Task<HttpResponseMessage> message = client.PostAsync("http://api.brightcove.com/services/post", content);
                var input = message.Result.Content.ReadAsStringAsync();
                Console.WriteLine(input.Result);
                Console.Read();
            }
        }
    }
