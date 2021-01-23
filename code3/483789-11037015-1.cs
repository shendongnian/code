    public static class MyExtensions {
    	public static IEnumerable<IEnumerable<T>> Paginate<T>(this IEnumerable<T> source, int pageSize) {
    		T[] buffer = new T[pageSize];
    		int index = 0;
    		
    		foreach (var item in source) {
    			buffer[index++] = item;
    			
    			if (index >= pageSize) {
    				yield return buffer.Take(pageSize);
    				index = 0;
    			}
    		}
    		
    		if (index > 0) {
    			yield return buffer.Take(index);
    		}
    	}
    }
