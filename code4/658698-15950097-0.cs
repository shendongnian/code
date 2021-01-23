    	public async Task<bool> CreateNewData (Data nData)
		{
			APIResponse serverReply;
			MultipartFormDataContent form = new MultipartFormDataContent ();
			form.Add (new StringContent (_partnerKey), "partnerKey");
			form.Add (new StringContent (UserData.Instance.key), "key");
			form.Add (new StringContent (nData.ToJson ()), "erList");
			if (nData._FileLocation != null) {
				string good_path = nData._FileLocation.Substring (7); // Dangerous
				byte[] PictureData = File.ReadAllBytes (good_path);
				HttpContent content = new ByteArrayContent (PictureData);
				content.Headers.Add ("Content-Type", "image/jpeg");
				form.Add (content, "picture_0", "picture_0");
			}
			form.Add (new StringContent (((int)(DateTime.Now.ToUniversalTime () -
				new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds).ToString ()), "time");
			serverReply = await MakePostRequest (_baseURL + "Data-report/create", form);
			if (serverReply.Status == SERVER_OK)
				return (true);
			Android.Util.Log.Error ("MyApplication", serverReply.Response);
			return (false);
		}
		private async Task<APIResponse> MakePostRequest (string RequestUrl, MultipartFormDataContent Content)
		{
			HttpClient httpClient = new HttpClient ();
			APIResponse serverReply = new APIResponse ();
			try {
				Console.WriteLine ("MyApplication - Sending Request");
				Android.Util.Log.Info ("MyApplication", " Sending Request");
				HttpResponseMessage response = await httpClient.PostAsync (RequestUrl, Content).ConfigureAwait (false);
				serverReply.Status = (int)response.StatusCode;
				serverReply.Response = await response.Content.ReadAsStringAsync ();
			} catch (HttpRequestException hre) {
				Android.Util.Log.Error ("MyApplication", hre.Message);
			}
			return (serverReply);
		}
