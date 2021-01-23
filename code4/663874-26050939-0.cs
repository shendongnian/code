	void Main()
	{
		var ProtectedChars = "0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6A, 0x6B, 0x6C, 0x6D, 0x6E, 0x6F, 0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78, 0x79, 0x7A".Replace(" 0x", "%").Split(',');
		var client = new RestClient("https://api.twitter.com");
	
		client.Authenticator = OAuth1Authenticator.ForProtectedResource(
			"_consumerKey", "_consumerSecret", "_accessToken", "_accessTokenSecret"
		);
		
		var status = "Dogs, Cats & Mice";
		
		string newStatus = string.Empty;
		
		foreach (char c in status)
		{
			var charBytes = Encoding.UTF8.GetBytes(c.ToString());
			var tempText = string.Empty;
			
			for (int i = 0; i < charBytes.Count(); i++)
			{
				byte b = charBytes[i];
				string hex = "%" + b.ToString("X2");
				tempText += hex;
			}
			
			if (ProtectedChars.Any(x => x == tempText))
			{
				newStatus += c;
			}
			else
			{
				newStatus += string.Format("{0:X2}", tempText);
			}
		}
		
		var request = new RestRequest("/1.1/statuses/update.json", Method.POST);
		request.AddParameter(new Parameter{ Name = "status", Type = ParameterType.GetOrPost, Value = newStatus } );
		
		var response = client.Execute(request);
	
	
	}
