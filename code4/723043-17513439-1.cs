    string rawOut = "Results:\r\n___ % done\r 10\r 20\r 30\r\nError!";
    string[] lines = Regex.Split(rawOut, Environment.NewLine);
    for(int j=0; j<lines.Length; j++)
    {
    	string line = lines[j];
    	if (line.Contains('\r'))
    	{
    		string[] subLines = line.Split('\r');
    		char[] mainLine = subLines[0].ToCharArray();
    		for(int i=1; i<subLines.Length; i++)
    		{
    			string subLine = Regex.Replace(subLines[i], ".\x0008(.)", "$1");
    			if (subLine.Length > mainLine.Length) mainLine = subLine.ToCharArray();
    			else subLine.CopyTo(0, mainLine, 0, subLine.Length);
    		}
    		lines[j] = new String(mainLine);
    	}
    }
