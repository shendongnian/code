    private Queue<StringBuilder> writeQueue;
    private bool isComplete;
    
    public void FileWriter()
    {
    	this.isComplete = false;
    	this.writeQueue = new Queue<StringBuilder>();
    
    	var writer = new Action<string>(this.StartWriting);
    	var writerAsync = writer.BeginInvoke(@"outputfile.txt", null, null);
    
    	using (StreamReader sr = new StreamReader(@"inputfile.txt"))
    	{
    		var fileHeaders = sr.ReadLine()
    			.Split('\t')
    			.Where(i => !string.IsNullOrEmpty(i))
    			.Select(j => j.Trim())
    			.ToList();
    
    		var buffer = new StringBuilder();
    		while (!sr.EndOfStream)
    		{
    			var originalLine = sr.ReadLine()
    				.Split('\t')
    				.Where(i => !string.IsNullOrEmpty(i))
    				.Select(j => j.Trim())
    				.ToList();
    
    			var line = new StringBuilder();
    			//Must have same number of items
    			if (originalLine.Count == fileHeaders.Count)
    			{
    				for (int i = 0; i < fileHeaders.Count(); i++)
    				{
    					line.AppendFormat("{0}={1}&", fileHeaders[i], originalLine[i]);
    				}
    				line.AppendLine();
    			}
    
    			buffer.AppendLine(line.ToString());
    			if (buffer.Length > 1024 * 1024 * 10)//approx 10MB 
    			{
    				lock (this.writeQueue)
    				{
    					this.writeQueue.Enqueue(buffer);
    				}
    				buffer = new StringBuilder();
    			}
    		}
    		//Queue any final remaining data
    		if (buffer.Length>0) lock (this.writeQueue)
    		{
    			this.writeQueue.Enqueue(buffer);
    		}
    	}
    	this.isComplete = true;
    	writer.EndInvoke(writerAsync);
    }
    
    private void StartWriting(string outFilePath)
    {
    	while (!this.isComplete || this.writeQueue.Count > 0)
    	{
    		StringBuilder queuedItem;
    		if (this.writeQueue.Count > 0)
    		{
    			lock (this.writeQueue)
    			{
    				queuedItem = this.writeQueue.Dequeue();
    			}
    			File.AppendAllText(outFilePath, queuedItem.ToString());
    		}
    		System.Threading.Thread.Sleep(5000); //Sleep 5sec
    	}
    }
