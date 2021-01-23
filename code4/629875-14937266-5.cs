    void Rotate<TResult, TGroup>(IEnumerable<TResult> datesList, Func<TResult, TGroup> grouper, int rotation, out List<TResult> listA, out List<TResult> listB)
    {
    	listA = new List<TResult>();
    	listB = new List<TResult>();
    	
    	var weeks = datesList.GroupBy(grouper).ToList();
    	
    	var c_rotation = 0;
    	var c_list = listA;
    	
    	using (var en = weeks.GetEnumerator())
    		while(en.MoveNext())
    		{
    			c_list.AddRange((IGrouping<TGroup, TResult>)en.Current);
    			c_rotation++;
    			if (c_rotation == rotation)
    			{
    				c_rotation = 0;
    				c_list = c_list == listA ? listB : listA;
    			}
    		}
    }
