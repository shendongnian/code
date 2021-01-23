    var merged = new HashSet<string[]>(blocksComparisonSet1, new SEC());
    merged.UnionWith(blocksComparisonSet2);
    
    class SEC : IEqualityComparer<string[]>
    {
    	public bool Equals(string[] p1, string[] p2){
    		return p1.SequenceEqual(p2);
    	}
    	public int GetHashCode(string[] p){ 
    		return (int)p.Sum (p1 => p1.GetHashCode()); 
    	}
    }
