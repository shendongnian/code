		//string val = "12345678";
		string val = "12.34.56.78";
		string ret = val;
		int index = val.LastIndexOf(".");
		if (index >= 0)
		{
			ret = val.Substring(0, index).Replace(".", "") + val.Substring(index);
		}
		Debug.WriteLine(ret);
