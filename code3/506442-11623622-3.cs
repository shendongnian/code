    public static Dictionary<string, string> FASTAFileReadIn(string file) {
    	var seq = new Dictionary<string, string>();
    
    	Regex re = new Regex(@"^>(\S+)", RegexOptions.Compiled);
    	Regex nonWhitespace = new Regex(@"\S", RegexOptions.Compiled);
    	Match m;
    	string currentName = string.Empty;
    
    	try {
    		foreach(string line in File.ReadLines(file)) {
    			if(line[0] == '>') {
    				m = re.Match(line);
    
    				if(m.Success) {
    					if(!seq.ContainsKey(m.Groups[1].Value)) {
    						seq.Add(m.Groups[1].Value, string.Empty);
    						currentName = m.Groups[1].Value;
    					}
    				}
    			} else if(currentName != string.Empty) {
    				if(nonWhitespace.IsMatch(line)) {
    					seq[currentName] += line.Trim();
    				}
    			}
    		}
    	} catch(IOException e) {
    		Console.WriteLine("An IO exception has been thrown!");
    		Console.WriteLine(e.ToString());
    	}
    
    	return seq;
    }
