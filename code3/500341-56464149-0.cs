    private IEnumerable<IList<T>> SplitList<T>(IList<T> list, int totalChunks)
    {
    	IList<T> auxList = new List<T>();
    	int totalItems = list.Count();
    	
    	if (totalChunks <= 0)
    	{
    		yield return auxList;
    	}
    	else 
    	{
    		for (int i = 0; i < totalItems; i++)
    		{				
    			auxList.Add(list[i]);			
    		
    			if ((i + 1) % totalChunks == 0)
    			{
    				yield return auxList;
    				auxList = new List<T>();				
    			}
    			
    			else if (i == totalItems - 1)
    			{
    				yield return auxList;
    			}
    		}
    	}	
    }
