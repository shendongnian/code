    public override int GetHashCode()
    {
       return GetHashCodeInternal(Row.GetHashCode(),Column.GetHashCode());
    }
    //this function should be move so you can reuse it
    private static int GetHashCodeInternal(int key1, int key2)
    {
    	unchecked
    	{
    		//Seed
    		var num = 0x7e53a269;
    
    		//Key 1
    		num = (-1521134295 * num) + key1;
    		num += (num << 10);
    		num ^= (num >> 6);
    
    		//Key 2
    		num = ((-1521134295 * num) + key2);
    		num += (num << 10);
    		num ^= (num >> 6);
    
    		return num;
    	}
    }
