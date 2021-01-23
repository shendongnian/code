    string[] lines = System.IO.File.ReadAllLines(input_file);
    var result = new List<string>();
    foreach(var line in lines)
    {
    	var strings = line.Split('\t');
    	var newLine = "";
    	foreach(var s in strings)
    	{
    		var newString = s.Replace('ý','\t');
    		var count = newString.Count(f=>f=='\t');
    		if (count<4)
    			for(int i=0; i<4-count; i++)
    				newString += "\t";
    		newLine += newString + "\t";
    	}
    	result.Add(newLine);
    }
    File.WriteAllLines(output_file, result);
