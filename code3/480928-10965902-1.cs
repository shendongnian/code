	private IObservable<string> GetResponse(
		string url,
		Dictionary<string, string> theQueryData)
	{
		return Observable.Start(() =>
		{
			var theRequest = WebRequest.Create(url);
			theRequest.Method = "POST";
			theRequest.ContentType="application/x-www-form-urlencoded";
	
			theQueryData.Add("apikey", APIKey);
			
			string Parameters = String.Join("&",
				theQueryData.Select(x =>
					String.Format("{0}={1}", x.Key, x.Value)));
			theRequest.ContentLength = Parameters.Length;
	
			using (var sw = new StreamWriter(theRequest.GetRequestStream()))
			{
				sw.Write(Parameters);
				sw.Close();
			}
	
			using (var theResponse =  (HttpWebResponse)theRequest.GetResponse())
			{
				using (var sr = new StreamReader(theResponse.GetResponseStream()))
				{
					return sr.ReadToEnd();
				}
			}
		});
	}
