	static void Main(string[] args)
	{
		var accessToken = GetAccessToken();
		Console.WriteLine("Access token is " + accessToken);
		var fileToUpload = @"C:\Program Files\Common Files\Microsoft Shared\ink\en-US\join.avi";
		Console.WriteLine("File to upload is " + fileToUpload);
		var uploadUrl = GetFileUploadUrl(accessToken);
		Console.WriteLine("Posting to " + uploadUrl);
		var response = UploadFileCompletedEventArgs(fileToUpload, accessToken, uploadUrl);
		Console.WriteLine("Response:\n");
		Console.WriteLine(response + "\n");
		Console.WriteLine("Done. Press enter to exit.");
		Console.ReadLine();
	}
	private static UploadResponse UploadFileCompletedEventArgs(string fileToUpload, string accessToken, string uploadUrl)
	{
		var client = new WebClient();
		client.Headers.Add("Authorization", "OAuth " + accessToken);
		var responseBytes = client.UploadFile(uploadUrl, fileToUpload);
		var responseString = Encoding.UTF8.GetString(responseBytes);
		var response = JsonConvert.DeserializeObject<UploadResponse>(responseString);
		return response;
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
	private static string GetFileUploadUrl(string accessToken)
	{
		var client = new WebClient();
		client.Headers.Add("Authorization", "OAuth " + accessToken);
		var urlResponse = client.DownloadString("https://api.dailymotion.com/file/upload");
		var response = JsonConvert.DeserializeObject<UploadRequestResponse>(urlResponse).upload_url;
		return response;
	}
