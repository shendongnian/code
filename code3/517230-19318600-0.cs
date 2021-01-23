            using (HttpClient httpClient = new HttpClient()) {
                httpClient.DefaultRequestHeaders.ConnectionClose = true;
                httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("MySoundCloudClient", "1.0"));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth", "MY_AUTH_TOKEN");
                ByteArrayContent titleContent = new ByteArrayContent(Encoding.UTF8.GetBytes("my title"));
                ByteArrayContent sharingContent = new ByteArrayContent(Encoding.UTF8.GetBytes("private"));
                ByteArrayContent byteArrayContent = new ByteArrayContent(File.ReadAllBytes("MYFILENAME"));
                byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                MultipartFormDataContent content = new MultipartFormDataContent();
                content.Add(titleContent, "track[title]");
                content.Add(sharingContent, "track[sharing]");
                content.Add(byteArrayContent, "track[asset_data]", "MYFILENAME");
                HttpResponseMessage message = await httpClient.PostAsync(new Uri("https://api.soundcloud.com/tracks"), content);
                if (message.IsSuccessStatusCode) {
                    ...
                }
