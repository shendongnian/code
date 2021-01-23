    var sourcePath = @"C:\data.csv";
    var delimiter = ",";
    var firstLineContainsHeaders = true;
    var tempPath = Path.GetTempFileName();
    var lineNumber = 0;
    
    using (var writer = new StreamWriter(tempPath))
    using (var reader = new StreamReader(sourcePath))
    {
        var d = new { delimiter };
    	string line = null;
    	string[] headers = null;
    	if (firstLineContainsHeaders)
    	{
    		line = reader.ReadLine();
    		lineNumber++;
    		
    		if (string.IsNullOrEmpty(line)) return; // file is empty;
    		
    		headers = line.Split(d, StringSplitOptions.None);
    		
    		writer.WriteLine(line); // write the original header to the temp file.
    	}
    	
    	while ((line = reader.ReadLine()) != null)
    	{
    		lineNumber++;
    		
    		var columns = line.Split(d, StringSplitOptions.None);
    		
    		// if there are no headers, do a simple sanity check to make sure you always have the same number of columns in a line
    		if (headers == null) headers = new string[columns.Length];
    		
    		if (columns.Length != headers.Length) throw new InvalidOperationException(string.Format("Line {0} is missing one or more columns.", lineNumber));
    		
    		// TODO: search and replace in columns
    		
    		writer.WriteLine(string.Join(delimiter, columns));
    	}
    
    }
    
    File.Delete(sourcePath);
    File.Move(tempPath, sourcePath);
