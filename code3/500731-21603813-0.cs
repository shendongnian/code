    private List<List<string>> GetCombinations()
    {
    	
    	List<List<string>> mResult= new List<List<string>>();
    	
    	for (int i = 0; i < mList.Count; i++)
    	{
    		for (int k = 0; k < mList.Count; k++)
    		{
    			if (i == k) continue;
    			
    			List<string> tmpList = new List<string>();
    			
    			tmpList.Add(mList[i]);
    			int mCount = 1;
    			int j = k;
    			while (true)
    			{
    				
    				if (j >= mList.Count) j = 0;
    				if (i != j)
    				{
    			
    					tmpList.Add(mList[j]);
    					mCount++;
    				}
    				j += 1;
    				if (mCount >= mList.Count) break;
    			}
    			
    			mResult.Add(tmpList);
    		}
    		
    	}
    	return mResult;
    }
