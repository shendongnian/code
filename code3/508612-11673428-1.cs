    class Holder
    {
    	   public dynamic max = null;
    	   public int count = 0;
    }
    void Main()
    {
    	var data = new List<dynamic>
    	    {new { x = 1 }, new { x = 2 }, new { x = 3 }, 
    		 new { x = 3 }, new { x = 10}, new { x = 1 }, 
    		 new { x = 5 }, new { x = 2 }, new { x = 1 },
    		 new { x = 1 }, new { x = 9 }, new { x = 3 }, 
    		 new { x = 11}, new { x = 10}, new { x = 1 }, 
    		 new { x = 5 }, new { x = 2 }, new { x = 12 }};
    	 
    	var x = data.Aggregate(
    	   new LinkedList<Holder>(),
    	   (holdList,inItem) => 
    	   {
    	      if ((holdList.Last == null) || (holdList.Last.Value.count == 3))
    		  {
    		    holdList.AddLast(new Holder { max = inItem, count = 1});
    		  }
    		  else
    		  {
    		    if (holdList.Last.Value.max.x < inItem.x)
    			   holdList.Last.Value.max = inItem;
    			
    			holdList.Last.Value.count++;
    		  }
    	      return holdList;
    	   },
    	   (holdList) => { return holdList.Select((h) => h.max );} );
    
    	x.Dump("We expect 3,10,5,9,11,12");
    }
