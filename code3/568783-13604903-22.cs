    private string YTplayer_CallFlash(string ytFunction){
    	string flashXMLrequest = "";
    	string response="";
    	string flashFunction="";
    	List<string> flashFunctionArgs = new List<string>();
    
    	Regex func2xml = new Regex(@"([a-z][a-z0-9]*)(\(([^)]*)\))?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    	Match fmatch = func2xml.Match(ytFunction);
    
    	if(fmatch.Captures.Count != 1){
    		Console.Write("bad function request string");
    		return "";
    	}
    
    	flashFunction=fmatch.Groups[1].Value.ToString();
    	flashXMLrequest = "<invoke name=\"" + flashFunction + "\" returntype=\"xml\">";
    	if (fmatch.Groups[3].Value.Length > 0)
    	{
    		flashFunctionArgs = pars*emphasized text*eDelimitedString(fmatch.Groups[3].Value);
    		if (flashFunctionArgs.Count > 0)
    		{
    			flashXMLrequest += "<arguments><string>";
    			flashXMLrequest += string.Join("</string><string>", flashFunctionArgs);
    			flashXMLrequest += "</string></arguments>";
    		}
    	}
    	flashXMLrequest += "</invoke>";
    
    	try
    	{
    		Console.Write("YTplayer_CallFlash: \"" + flashXMLrequest + "\"\r\n");
    		response = YTplayer.CallFunction(flashXMLrequest);                
    		Console.Write("YTplayer_CallFlash_response: \"" + response + "\"\r\n");
    	}
    	catch
    	{
    		Console.Write("YTplayer_CallFlash: error \"" + flashXMLrequest + "\"\r\n");
    	}
    
    	return response;
    }
    
    private static List<string> parseDelimitedString (string arguments, char delim = ',')
    {
    	bool inQuotes = false;
    	bool inNonQuotes = false;
    	int whiteSpaceCount = 0;
    	
    	List<string> strings = new List<string>();
    
    	StringBuilder sb = new StringBuilder();
    	foreach (char c in arguments)
    	{
    		if (c == '\'' || c == '"')
    		{
    			if (!inQuotes)
    				inQuotes = true;
    			else
    				inQuotes = false;
    
    			whiteSpaceCount = 0;
    		}else if (c == delim)
    		{
    			if (!inQuotes)
    			{
    				if (whiteSpaceCount > 0 && inQuotes)
    				{
    					sb.Remove(sb.Length - whiteSpaceCount, whiteSpaceCount);
    					inNonQuotes = false;
    				}
    				strings.Add(sb.Replace("'", string.Empty).Replace("\"", string.Empty).ToString());
    				sb.Remove(0, sb.Length);                       
    			}
    			else
    			{
    				sb.Append(c);
    			}
    			whiteSpaceCount = 0;
    		}
    		else if (char.IsWhiteSpace(c))
    		{                    
    			if (inNonQuotes || inQuotes)
    			{
    				sb.Append(c);
    				whiteSpaceCount++;
    			}
    		}
    		else
    		{
    			if (!inQuotes) inNonQuotes = true;
    			sb.Append(c);
    			whiteSpaceCount = 0;
    		}
    	}
    	strings.Add(sb.Replace("'", string.Empty).Replace("\"", string.Empty).ToString());
    
    
    	return strings;
    }
