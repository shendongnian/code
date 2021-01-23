    public class IdComparer : IComparer<Item> {
    	private readonly Dictionary<int, int> idIndexes;
    	public IdComparer(IEnumerable<int> sortedIds)
    	{
    		idIndexes = sortedIds
    			.Select((id, idx) => new { Id = id, Index = idx })
    			.ToDictionary(p => p.Id, p.Index);
    	}
    	
    	public int Compare(Item x, Item y) {
    		xIndex = idIndexes[x.Id];
    		yIndex = idIndexes[y.Id]
    		return xIndex.CompareTo(yIndex);
    	}
    }
