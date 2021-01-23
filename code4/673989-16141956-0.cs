	public static bool isAnagram(String s, String t)
	{
		if (s == "" || t == "") return false;
		else if (s.Length != t.Length) return false;
		while (s.Length > 0)
		{
			char first = s[0];
			string search = new string(first, 1);
			if (Char.IsHighSurrogate(first))
			{
				char second = s[1];	//Assumed to work - if it doesn't, the input was malformed
				search = new string(new char[] { first, second });
			}
			int index = t.IndexOf(search);
			if (index < 0) return false;
			t = index > 0 ? t.Substring(0, index) : "" + t.Substring(index + search.Length);
			s = s.Substring(search.Length);
		}
		return true;
	}
