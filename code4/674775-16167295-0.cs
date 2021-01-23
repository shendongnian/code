    var lines = File.ReadAllLines("path").ToList();
    var regex = new Regex(@"^[0]{1,2}");
    var startFrom = lines.IndexOf("[Destinations]");
    
    //Start replacing from the index of "[Destinations]"
    for (int i = startFrom; i < lines.Count; i++)
    {
    	//Assuming the ini section ends at an empty line - stop replacing
    	if(lines[i].Trim() == string.Empty)
    		break;
    		
    	lines[i] = regex.Replace(lines[i], "+");
    }
    
    File.WriteAllLines("path", lines);
