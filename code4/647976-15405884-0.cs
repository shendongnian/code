    int MaxCount = List1.Count; //Or whatever the highest list count.
    			
    			for (int i = 0; i < MaxCount; i++)
    				{
    					if( list1.Count > i)
    					combined.Add(list1[i]);
       
    					if( list2.Count > i)
    					combined.Add(list2[i]);
       
    					if( list3.Count > i)
    					combined.Add(list3[i]);
    				}
