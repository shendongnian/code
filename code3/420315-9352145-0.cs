    public int CompareTo(int value)
    {
        if (this < value)
        {
    	   return -1;
        }
        if (this > value)
        {
    	   return 1;
        }
        return 0;
    }
