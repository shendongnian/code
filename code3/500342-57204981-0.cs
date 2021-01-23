    public static IList<IList<T>> SplitList<T>(this IList<T> list, int chunkSize)
    {
    	var chunks = new List<IList<T>>();
    	List<T> chunk = null;
    	for (var i = 0; i < list.Count; i++)
    	{
    		if (i % chunkSize == 0)
    		{
    			chunk = new List<T>(chunkSize);
    			chunks.Add(chunk);
    		}
    		chunk.Add(list[i]);
    	}
    	return chunks;
    }
