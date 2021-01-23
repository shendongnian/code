    RemoveOutsideZeros(ref StatusList);
                    StatusList.Reverse();
    RemoveOutsideZeros(ref StatusList);
    				
    				
    private void RemoveOutsideZeros(ref List<StatusData> StatusList)
    {
    	bool Found0 = false;
    	foreach (StatusData i in StatusList.ToList())
    	{
    		if (i.Count != 0)
    	{
    		Found0 = true;
    	}
    		if (i.Count == 0 && Found0 == false)
    		{
    			StatusList.Remove(i);
    		}
    	}
}
