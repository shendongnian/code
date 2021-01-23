    public class AdvancedList : List<int>
    {
    	public int Last
    	{
    	    get { return this[Count - 1]; }
    	    set
            {
                if(Count >= 1 )
                    this[Count - 1] = value;
                else
                    Add(value);
            }
    	}
    }
    
    AdvancedList advancedList = new AdvancedList();
    advancedList.Add(100);
    advancedList.Add(200);
    advancedList.Last = 10;
    
    advancedList.Last = 11;
