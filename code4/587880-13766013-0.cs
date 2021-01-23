    public class ValueComparator : IComparer
    {
    	public override int Compare(object ob1, object ob2)
    	{
    		int retval = 0;
    		if (ob1 is DataCol && ob2 is DataCol)
    		{
    			DataCol c1 = (DataCol) ob1;
    			DataCol c2 = (DataCol) ob2;
    			if (c1.value < c2.value) retval = 1;
    			if (c1.value > c2.value) retval = -1;
    		}
    		else
    		{
    			throw new ClassCastException("ValueComparator: Illegal arguments!");
    		}
    		return (retval);
    	}
    }
