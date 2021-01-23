    using System.IO;
        
    string[] csvFile = File.ReadAllLines(pathToCsv);
    foreach (string line in csvFile)
    {
    	// get the first comma in the line
    	// everything before this index is the row number
    	// everything after is the row value
    	int firstCommaIndex = line.IndexOf(',');
    	
    	//Note: SubString used here is (startIndex, length) 
    	string row = line.Substring(0, firstCommaIndex+1);
    	string rowValue = line.Substring(firstCommaIndex+1).Trim();
    	
    	Console.WriteLine("This line was parsed as:\n{0},{1}",
    			row, rowValue);
    }
