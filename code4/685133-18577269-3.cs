    static void Main(string[] args)
    {
    	// This project should be compiled with "unsafe" flag!
    	Console.WriteLine(GetRawCommandLine());
    	var prms = GetRawArguments();
    	foreach (var prm in prms)
    	{
    		Console.WriteLine(prm);
    	}
    }
    
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    private static extern System.IntPtr GetCommandLine();
    public static string GetRawCommandLine()
    {
        // Win32 API
    	string s = Marshal.PtrToStringAuto(GetCommandLine());
        
        // or better, managed code as suggested by @mp3ferret
        // string s = Environment.CommandLine;
        return s.Substring(s.IndexOf('"', 1) + 1).Trim();
    }
    
    public static string[] GetRawArguments()
    {
    	string cmdline = GetRawCommandLine();
    
    	// Now let's split the arguments. 
    	// Lets assume the fllowing possible escape sequence:
    	// \" = "
    	// \\ = \
    	// \ with any other character will be treated as \
    	//
    	// You may choose other rules and implement them!
    
    	var args = new ArrayList();
    	bool inQuote = false;
    	int pos = 0;
    	StringBuilder currArg = new StringBuilder();
    	while (pos < cmdline.Length)
    	{
    		char currChar = cmdline[pos];
    
    		if (currChar == '"')
    		{
    			currArg.Append(currChar);
    			inQuote = !inQuote;
    		}
    		else if (currChar == '\\')
    		{
    			char nextChar = pos < cmdline.Length - 1 ? cmdline[pos + 1] : '\0';
    			if (nextChar == '\\' || nextChar == '"')
    			{
    				currArg.Append(nextChar);
    				pos += 2;
    				continue;
    			}
    			else
    			{
    				currArg.Append(currChar);
    			}
    		}
    		else if (inQuote || !char.IsWhiteSpace(currChar))
    		{
    			currArg.Append(currChar);
    		}
    		if (!inQuote && char.IsWhiteSpace(currChar) && currArg.Length > 0)
    		{
    			args.Add(currArg.ToString());
    			currArg.Clear();
    		}
    		pos++;
    	}
    
    	if (currArg.Length > 0)
    	{
    		args.Add(currArg.ToString());
    		currArg.Clear();
    	}
    	return (string[])args.ToArray(typeof(string));
    }
