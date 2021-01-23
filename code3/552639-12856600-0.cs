	public System.IObservable<string> Result(
		string input, string type, bool sensitive)
	{
		return Observable.Start(() =>
		{
			var csv = "\"Roundtrip Time\",\"Status\"\n";
		
			if (sensitive == true)
			{
				csv += "\"\",\"FORBIDDEN\"\n";
			}
			else
			{
				var input2 = type == "URL" ? new Uri(input).Host : input;
				ver ping = new Ping();
				ver pingReply = ping.Send(input2);
		
				csv += String.Format("\"{0}\",\"{1}\"\n",
					pingReply.RoundtripTime, pingReply.Status);
			}
		
			return csv;
		});
	}
