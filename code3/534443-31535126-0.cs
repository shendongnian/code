    public JsonToken getCSRFToken(){
			var request = HttpWebRequest.Create(string.Format(this.apiBaseUrl + @"/druidapi/user/token.json"));
			request.ContentType = "application/json";
			request.Method = "GET";
			Console.Out.WriteLine("GET call to: {0}", this.apiBaseUrl.ToString() + @"/druidapi/user/token.json");
			using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
			{
				if (response.StatusCode != HttpStatusCode.OK)
					Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
				using (StreamReader reader = new StreamReader(response.GetResponseStream()))
				{
					var content = reader.ReadToEnd();
					if(string.IsNullOrWhiteSpace(content)) {
						Console.Out.WriteLine("Response contained empty body...");
					}
					else {
						Console.Out.WriteLine("Response Body: \r\n {0}", content);
					}
					if (content == null) {
						throw new Exception ("content is NULL");
					} else {
						
						JsonToken deserializedToken = JsonConvert.DeserializeObject<JsonToken>(content);
						return deserializedToken;
					}
				}
			}
		}
