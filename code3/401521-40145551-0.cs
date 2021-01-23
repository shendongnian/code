    string raw = "hello this is #Totally #Awesome, right? #yeah!";
    List<string> hashtags = new List<string>();
    StringBuilder sb = null;
	foreach (char c in raw.ToLower())
	{
		if (c == '#')
		{
			sb = new StringBuilder();
			track = true;
		}
		else if (track)
		{
			if (char.IsLetterOrDigit(c))
			{
				sb.Append(c);
			}
			else
			{
				hashtags.Add(sb.ToString());
				track = false;
			}
		}
	}
