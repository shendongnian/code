    // Method to split a line into a string array separated by whitespace
    private string[] Splitter(string input)
    {
        return Regex.Split(intput, @"\W+");
    }
    
    
    // Another code snippet to  read the file and break the lines into arrays 
    // of strings and store the arrays in a list.
    List<String[]> arrayList = new List<String[]>();
    
    using (FileStream fStream = File.OpenRead(@"C:\SomeDirectory\SomeFile.txt"))
    {
    	using(TextReader reader = new StreamReader(fStream))
    	{
    		string line = "";
    		while(!String.IsNullOrEmpty(line = reader.ReadLine()))
    		{
    			arrayList.Add(Splitter(line));
    		}
    	}
    } 
