    public class OrderComparer : IComparer<What>
    {
    	private readonly Dictionary<int, int> idIndexes = new Dictionary<int, int>();
    	public OrderComparer(List<int> idOrders)
    	{
    		for(int i = 0; i < idOrders.Length; i++)
    		{
    			idIndexes[idOrders[i].ID] = i;
    		}
    	}
    	
    	public int Compare(What x, What y)
    	{
    		return idOrders[x.ID].Compare(idOrders[y.ID]);
    	}
    }
