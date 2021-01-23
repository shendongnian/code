    public List<int> AllCodesList
    {
        get
        {
    		List<int> subDivisions = null;
    		if (SubdivisionInfoList.Any(s => s.code > 0))
    		{
    			subDivisions = (from subdivision in SubdivisionInfoList
                    where subdivision.code > 0 
                    select subdivision.code).ToList();
    		}
            return subDivisions;
        }
    }
