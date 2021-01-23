    static class Ex
    {
    	public static IEnumerable<IEnumerable<TValue>> Chunk<TValue>(
            this IEnumerable<TValue> values, 
            Int32 chunkSize)
    	{
    		return values
                   .Select((v, i) => new {v, groupIndex = i / chunkSize})
                   .GroupBy(x => x.groupIndex)
                   .Select(g => g.Select(x => x.v));
    	}
    }
