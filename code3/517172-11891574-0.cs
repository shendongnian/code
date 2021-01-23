    HList findHListentry(string letter)
    {
    	if (string.IsNullOrWhiteSpace(letter))
    	{
    		HList result = listentry.Find(delegate(HList bk) { return bk.letter == letter; });
    		return result;
    	}
    	else
    	{
    		return HList.Empty;
    	}
    }
    
    public struct HList
    {
    	public const HList Empty;
    }
