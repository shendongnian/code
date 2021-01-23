    class MultiKey<T1, T2, T3> : HashSet<Tuple<T1, T2, T3>>
    {
    	public bool Add(T1 t1, T2 t2, T3 t3)
    	{
    		return this.Add(Tuple.Create(t1, t2, t3));
    	}
    	public T1 Get(T2 t2, T3 t3)
    	{
    		var match = this.SingleOrDefault(x => x.Item2.Equals(t2) && x.Item3.Equals(t3));
    		if (match == null) return default(T1);
    		else return match.Item1;
    	}
    	public T2 Get(T1 t1, T3 t3)
    	{
    		var match = this.SingleOrDefault(x => x.Item1.Equals(t1) && x.Item3.Equals(t3));
    		if (match == null) return default(T2);
    		else return match.Item2;
    	}
    	public T3 Get(T1 t1, T2 t2)
    	{
    		var match = this.SingleOrDefault(x => x.Item1.Equals(t1) && x.Item2.Equals(t2));
    		if (match == null) return default(T3);
    		else return match.Item3;
    	}
    }
