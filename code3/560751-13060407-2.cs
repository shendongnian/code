    void Main()
    {
    	var list = new Queue<int>();
    	list.Enqueue(1);
    	list.Enqueue(2);
    	list.Enqueue(3);
    	list.Enqueue(4);
    	list.Enqueue(5);
    	
    	var random = new Random();
    	
    	int chunksize = 2;
    	foreach (var chunk in list.BreakListinChunks(chunksize))
    	{
    		foreach (var item in chunk)
    		{	
    			try
    			{	        
    				if(random.Next(0, 3) == 0) // 1 in 3 chance of error
    					throw new Exception(item + " is a problem");
    				else
    					Console.WriteLine (item + " is OK");
    			}
    			catch (Exception ex)
    			{
    				Console.WriteLine (ex.Message);
    				list.Enqueue(item);
    			}
    		}
    	}
    }
    
    public static class IEnumerableExtensions
    {	
    	public static IEnumerable<List<T>> BreakListinChunks<T>(this Queue<T> sourceList, int chunkSize)
    	{
    		List<T> chunkReturn = new List<T>(chunkSize);
    		while(sourceList.Count > 0)
    		{
    			chunkReturn.Add(sourceList.Dequeue());
    			if (chunkReturn.Count == chunkSize || sourceList.Count == 0)
    			{
    				yield return chunkReturn;
    				chunkReturn = new List<T>(chunkSize);
    			}		
    		}
    	}
    }
