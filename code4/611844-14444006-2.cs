	Task<string> GetContent(string rawContent)
	{
		var task = Task<string>.Factory.StartNew(() => 
		{
			var match = Regex.Match(rawContent, @"^(.*?<form .*?>(.*?)</form>.*?)+$", RegexOptions.Singleline);
			return match.Success ? match.Value : string.Empty;
		});
		return task;
	}
