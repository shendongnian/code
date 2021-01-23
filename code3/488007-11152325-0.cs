	public class Return
	{
		public static IAction Value(object result)
		{ 
		    return new ReturnAction(result);
		}
	}
	
