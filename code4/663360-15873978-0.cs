    public void test()
    {
    	object[,] RaWData = null;
    
    	dynamic range = xlWorkSheet.UsedRange;
    
    	//i am unsure here about the correct order - I do not work with excel at Work, so you might have to change the following lange, if columns needs to be before rows or so
    	RaWData = range.value2;
    
    	//I am using a list here, because Lists are a lot easier to work with then simple arrays
    	List<List<string>> RealData = new List<List<string>>();
    
    	//start at 1  because the excel-delivered array do not have values at index 0 - this is the only 1-based array you will ever encounter in .net
    	for (x = 1; x <= Information.UBound(RaWData, 1); x++) {
    		List<string> templist = new List<string>();
    		for (y = 1; y <= Information.UBound(RaWData, 2); y++) {
    			templist.Add(RaWData[x, y].ToString());
    		}
    		RealData.Add(templist);
    	}
    
    	//you should be finished here...
    }
