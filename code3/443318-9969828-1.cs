        static void Main(string[] args)
        {
            var accessToken = GetAccessToken();
            Authorize(accessToken);
            Console.WriteLine("Access token is " + accessToken);
            var fileToUpload = @"C:\Program Files\Common Files\Microsoft Shared\ink\en-US\join.avi";
            Console.WriteLine("File to upload is " + fileToUpload);
            var uploadUrl = GetFileUploadUrl(accessToken);
            Console.WriteLine("Posting to " + uploadUrl);
            var response = GetFileUploadResponse(fileToUpload, accessToken, uploadUrl);
            Console.WriteLine("Response:\n");
            Console.WriteLine(response + "\n");
            Console.WriteLine("Publishing video.\n");
            var uploadedResponse = PublishVideo(response, accessToken);
            Console.WriteLine(uploadedResponse);
            Console.WriteLine("Done. Press enter to exit.");
            Console.ReadLine();
        }
        private static UploadResponse GetFileUploadResponse(string fileToUpload, string accessToken, string uploadUrl)
        {
            var client = new WebClient();
            client.Headers.Add("Authorization", "OAuth " + accessToken);
            var responseBytes = client.UploadFile(uploadUrl, fileToUpload);
            var responseString = Encoding.UTF8.GetString(responseBytes);
            var response = JsonConvert.DeserializeObject<UploadResponse>(responseString);
            return response;
        }
        private static UploadedResponse PublishVideo(UploadResponse uploadResponse, string accessToken)
        {
            var request = WebRequest.Create("https://api.dailymotion.com/me/videos?url=" + HttpUtility.UrlEncode(uploadResponse.url));
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Authorization", "OAuth " + accessToken);
            var requestString = String.Format("title={0}&tags={1}&channel={2}&published={3}",
                HttpUtility.UrlEncode("some title"),
                HttpUtility.UrlEncode("tag1"),
                HttpUtility.UrlEncode("news"),
                HttpUtility.UrlEncode("true"));
            var requestBytes = Encoding.UTF8.GetBytes(requestString);
            var requestStream = request.GetRequestStream();
            requestStream.Write(requestBytes, 0, requestBytes.Length);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            string responseString;
            using (var reader = new StreamReader(responseStream))
            {
                responseString = reader.ReadToEnd();
            }
            var uploadedResponse = JsonConvert.DeserializeObject<UploadedResponse>(responseString);
            return uploadedResponse;
        }
        private static string GetAccessToken()
        {
            var request = WebRequest.Create("https://api.dailymotion.com/oauth/token");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            var requestString = String.Format("grant_type=password&client_id={0}&client_secret={1}&username={2}&password={3}",
                HttpUtility.UrlEncode(SettingsProvider.Key),
                HttpUtility.UrlEncode(SettingsProvider.Secret),
                HttpUtility.UrlEncode(SettingsProvider.Username),
                HttpUtility.UrlEncode(SettingsProvider.Password));
            var requestBytes = Encoding.UTF8.GetBytes(requestString);
            var requestStream = request.GetRequestStream();
            requestStream.Write(requestBytes, 0, requestBytes.Length);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            string responseString;
            using (var reader = new StreamReader(responseStream))
            {
                responseString = reader.ReadToEnd();
            }
            var oauthResponse = JsonConvert.DeserializeObject<OAuthResponse>(responseString);
            return oauthResponse.access_token;
        }
        private static void Authorize(string accessToken)
        {
            var authorizeUrl = String.Format("https://api.dailymotion.com/oauth/authorize?response_type=code&client_id={0}&scope=read+write+manage_videos+delete&redirect_uri={1}",
                HttpUtility.UrlEncode(SettingsProvider.Key),
                HttpUtility.UrlEncode(SettingsProvider.CallbackUrl));
            Console.WriteLine("We need permissions to upload. Press enter to open web browser.");
            Console.ReadLine();
            Process.Start(authorizeUrl);
            var client = new WebClient();
            client.Headers.Add("Authorization", "OAuth " + accessToken);
            Console.WriteLine("Press enter once you have authenticated and been redirected to your callback URL");
            Console.ReadLine();
        }
        private static string GetFileUploadUrl(string accessToken)
        {
            var client = new WebClient();
            client.Headers.Add("Authorization", "OAuth " + accessToken);
            var urlResponse = client.DownloadString("https://api.dailymotion.com/file/upload");
            var response = JsonConvert.DeserializeObject<UploadRequestResponse>(urlResponse).upload_url;
            return response;
        }
