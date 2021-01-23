		string ret = string.Empty;
		using (WebResponse response = request.GetResponse())
		{
			using (StreamReader reader = new StreamReader(response.GetResponseStream()))
			{
				ret = reader.ReadToEnd();
			}
		}
		return ret;
