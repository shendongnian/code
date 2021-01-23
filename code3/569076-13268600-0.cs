	var parsed = result.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None)
		.Select(x =>
		{ 
			int split = x.IndexOf('=');
			return new
			{
				Key = x.Substring(0, split),
				Value = x.Substring(split + 1, x.Length - (split + 1))
			};
		}).ToDictionary(k => k.Key, v => v.Value);
