	Dictionary<string, object> _dic = new Dictionary<string, object>();
	using(StreamReader reader = new StreamReader(file))
	{
		string text;
		while ((text = reader.ReadLine()) != null)
		{
			if (text.Equals(String.Empty))
				continue;
			string line = text.Trim();
			string[] keyval = line.Split('=');
			string value = keyval[1].Trim('"');
			string[] keys = keyval[0].Split('.');
			Dictionary<string, object> prevDic = _dic;
			for (int i = 0; i < keys.Length; i++)
			{
				if (i + 1 != keys.Length)
				{
					Dictionary<string, object> temp = new Dictionary<string, object>();
					if (prevDic.ContainsKey(keys[i]))
					{
						prevDic = prevDic[keys[i]] as Dictionary<string, object>; // Avoids exceptions when trying to cast the string value to a dictionary
						continue;
					}
					else
					{
						prevDic.Add(keys[i], temp);
						prevDic = temp;
					}
				}
				else
				{
					prevDic.Add(keys[i], value);
				}
			}
		}
	}
