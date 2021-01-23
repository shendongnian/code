    public void Diff(
    	string sourcePath,
    	string targetPath,
    	string patchPath,
    	string addedSuffix,
    	string removedSuffix)
    	
    {
    	using(var sourceReader = new StreamReader(sourcePath))
    	using(var targetReader = new StreamReader(targetPath))
    	using(var patchWriter = new StreamWriter(patchPath, append:false))
    	{	
    		var sourceLine = sourceReader.ReadLine();
    		var targetLine = targetReader.ReadLine();
    		
    		var added = new HashSet<string>();
    		var removed = new HashSet<string>();
    
    		do{
    			if(sourceLine == targetLine)
    			{	
    				sourceLine = sourceReader.ReadLine();
    				targetLine = targetReader.ReadLine();
    			}
    			else
    			{
    				if(removed.Contains(targetLine))
    				{
    					// Found targetLine in tentatively removed lines, so it wasn't actually removed.
    					removed.Remove(targetLine);
    					// Since we found something we thought had been removed, we know that all tentatively added lines actually are new.
    					Flush(patchWriter, added, addedSuffix);				
    					added.Clear();
    
    					targetLine = targetReader.ReadLine(); 				
    				} 
    				else if(added.Contains(sourceLine))
    				{
    					// Found sourceLine in tentatively added lines, so it wasn't actually added.
    					added.Remove(sourceLine);
    					// We found something we thought had been added, so all candidates for removal should actually be removed.
    					Flush(patchWriter,removed, removedSuffix);
    					removed.Clear();
    					
    					sourceLine = sourceReader.ReadLine(); 				
    				}
    				else
    				{
    					// Source and target don't match, so we assume that the source was removed and the target was added.
    					// If we're wrong, we'll clean it up when we come across the line later on.
    					removed.Add(sourceLine);
    					added.Add(targetLine);
    					sourceLine = sourceReader.ReadLine(); 				
    					targetLine = targetReader.ReadLine(); 				
    				}		
    			}	
    		} while(sourceLine != null || targetLine != null); 
    		
    		Flush(patchWriter, added, addedSuffix);
    		Flush(patchWriter, removed, removedSuffix);
    	}
    }
    
    public void Flush(StreamWriter writer, IEnumerable<string> lines, string suffix)
    {
    	foreach (var line in lines.Where (l => l != null))
    	{
    		writer.WriteLine("{0} {1}", line.Trim(), suffix);
    	}
    }
