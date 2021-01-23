    	private static bool CheckEqual(string s1, string s2)
		{
			char[] c1 = (s1 == null) ? new char[0] : s1.ToCharArray();
			char[] c2 = (s2 == null) ? new char[0] : s2.ToCharArray();
			if (c1.Length != c2.Length) { return false; }
			for (int i = 0; i < c1.Length; i++)
			{
				if (!c1[i].Equals(c2[i])) { return false; }
			}
			return true;
		}
