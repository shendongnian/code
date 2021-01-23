       public async Task Upload(string authorization, string filename, string parentID)
        {
            HttpRequestMessage message = new HttpRequestMessage();
            message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("BoxAuth", authorization);
            MultipartFormDataContent content = new MultipartFormDataContent();
            StreamContent streamContent = null;
            streamContent = new StreamContent(new FileStream(localURI, FileMode.Open));
            streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                FileName = "\"" + filename + "\"",
                Name = "\"filename\""
            };
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            content.Add(streamContent);
            ByteArrayContent byteContent = new ByteArrayContent(parentID.ToByteArray());
            byteContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"folder_id\""
            };
            content.Add(byteContent);
            message.Method = HttpMethod.Post;
            message.Content = content;
            message.RequestUri = new Uri("https://api.box.com/2.0/files/content");
            HttpResponseMessage response = null;
          
            Task<HttpResponseMessage> t = httpClient.SendAsync(message, cancelationToken);
            response = await t;
            if (t.IsCompleted)
            {
                if (!response.IsSuccessStatusCode)
                {
                    if (response.Content != null)
                        Logger.Error(await response.Content.ReadAsStringAsync(), "Box Upload");
                    else
                        Logger.Error("Error", "Box Upload");
                }
            }
        }
