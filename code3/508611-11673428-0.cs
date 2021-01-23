    void Main()
    {
    	var data = new List<dynamic> {new { x = 1 }, new { x = 2 }, new { x = 3 }, new { x = 3 },
                       new { x = 10}, new { x = 1 }, new { x = 5 }, new { x = 2 }, new { x = 1 } };
    	 
    	var x = data.Aggregate(new LinkedList<Holder>(new Holder [] {new Holder() }),(holdList,inItem) => 
    	   {
    		  var endList = holdList.Last.Value;
    	      if (endList.result == null)
    		  {
    		    if (endList.one == null)
    			  endList.one = inItem;
    			else  
    		    if (endList.two == null)
    			  endList.two = inItem;
    			else  
    			  if (endList.three == null)
    			  {
                    endList.three = inItem;
    				if (endList.one.x > endList.two.x)
    				  endList.result = endList.one;
    				else
    				  endList.result = endList.two;
    				  
    				if (endList.three.x > endList.result.x)
    				  endList.result = endList.three;
    		      }
    		  }
    		  else
    		  {
    		     holdList.AddLast(new Holder() { one = inItem });
    		  }
    		
    	    return holdList;
    	   },(holdList) => { return holdList.Select((h) => h.result );} );
    	
    	
    	data.Dump();
    	x.Dump();
    }
    
    // Define other methods and classes here
    class Holder
    {
    	   public dynamic one = null;
    	   public dynamic two = null;
    	   public dynamic three = null;
    	   
    	   public dynamic result = null;
    }
