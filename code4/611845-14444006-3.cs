	Task<string> GetContent(string rawContent)
	{
		var task = Task<string>.Factory.StartNew(ProcessContent, rawContent);
		return task;
	}
	
	string ProcessContent(object source)
	{
		var input = (string)source;
		var match = Regex.Match(input, @"^(.*?<form .*?>(.*?)</form>.*?)+$", RegexOptions.Singleline);
		return match.Success ? match.Value : string.Empty;
	}
