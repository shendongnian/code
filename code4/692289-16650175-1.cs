    public class PopularityContest{
    
    	private Dictionary<int, List<Result>> PopularityContainer { get; set; }
    	
    	private Dictionary<String, Result> ResultContainer { get; set; }
    	
    	private int MaxPopularity = 0;
    	
    	public PopularityContest(){
    		PopularityContainer = new Dictionary<int, List<Result>>();
    		ResultContainer = new Dictionary<String, Result>();
    	}
    	
    	private Object _SyncLock = new Object();
    	
    	public Result GetResult(string resultKey)
    	{
    	 
    	  Result result = ResultContainer[resultKey];
    	  
    	  lock(_SyncLock)
    	  {
    	 	  
    		int currentHits = result.Hits;
    	  
    	    if(PopularityContainer.ContainsKey(currentHits) && PopularityContainer[currentHits].Contains(result))
    	    {
    	       PopularityContainer[currentHits].Remove(result);
    	    }
    	  
    	    if(!PopularityContainer.ContainsKey(currentHits + 1))
    	    {
    	      PopularityContainer.Add(currentHits + 1, new List<Result>());
    	    }
    	  
    	    PopularityContainer[currentHits + 1].Add(Result);
    
            if((currentHits + 1) > MaxPopularity) { MaxPopularity = currentHits + 1;}
    
    	  }
    	  
    	  return result;
    	  
    	}
    	
    	
    	public void WritePopularity()
    	{
          //Here could also extract the keys to a List<Int32>, sort it, and walk that.
          //Note, as this is a read operation, dependent upon ordering, you would also consider locking here.
    	  for(int i = MaxPopularity; i >= 0; i--)
    	  {
    	     if(PopularityContainer.Contains(i) && PopularityContainer[i].Count > 0)
    	     {
                //NB the order of items at key[i] is the order in which they achieved their popularity
                foreach(Result result in PopularityContainer[i])
                {
    	        Console.WriteLine(String.Format("{0} has had {1} hits", result.ToString(), i));
                }
    	     }
    	  
    	  }
    	}
    	
    }
