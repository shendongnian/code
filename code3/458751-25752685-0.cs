	public static bool TryParsePoint(string s, out System.Drawing.Point p)
	{	p = new System.Drawing.Point();
		string s1 = "{X=";
		string s2 = ",Y=";
		string s3 = "}";
		int x1 = s.IndexOf(s1, StringComparison.OrdinalIgnoreCase);
		int x2 = s.IndexOf(s2, StringComparison.OrdinalIgnoreCase);
		int x3 = s.IndexOf(s3, StringComparison.OrdinalIgnoreCase);
		if (x1 < 0 || x1 >= x2 || x2 >= x3) { return false; }
		s1 = s.Substring(x1 + s1.Length, x2 - x1 - s1.Length);
		s2 = s.Substring(x2 + s2.Length, x3 - x2 - s2.Length); int i = 0;
		if (Int32.TryParse(s1, out i) == false) { return false; } p.X = i;
		if (Int32.TryParse(s2, out i) == false) { return false; } p.Y = i;
		return true;
	} // public static bool TryParsePoint(string s, out System.Drawing.Point p)
