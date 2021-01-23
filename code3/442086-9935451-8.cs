    var resultList = new List<string>();
    var temp = new List<string>();
    for(int i = 0, j = 1; j < originalList.Count; i++, j++)
    {
    	temp.Add(originalList[i]);
    	if (j != originalList.Count - 1)
    	{	
    		if (originalList[j].Contains("\t"))
    		{
    			resultList.Add(string.Join("|", temp));
    			temp.Clear();
    		}
    	}
    	else // when originalList[j] is the last item
    	{
    		if (originalList[j].Contains("\t"))
    		{
    			resultList.Add(string.Join("|", temp));
    			resultList.Add(originalList[j]);
    		}
    		else
    		{
    			temp.Add(originalList[j]);
    			resultList.Add(string.Join("|", temp));
    		}
    	}
    }
