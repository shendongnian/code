    StringBuilder b = new StringBuilder();
    foreach (string s in yourList)
	{
		b.Append(s);
                b.Append(", ");
	}
    
    string dir = "c:\mypath";
    File.WriteAllText(dir, b.ToString());
