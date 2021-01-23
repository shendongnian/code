    // Copyright (c) 2010 Alex Regueiro
    // Licensed under MIT license, available at 
    // <http://www.opensource.org/licenses/mit-license.php>.
    // Published originally at 
    // <http://blog.noldorin.com/2010/05/combinatorics-in-csharp/>.
    // Version 1.0, released 22nd May 2010.
    
    // modified by moi to be a generator 
    public static IEnumerable<T[]> GetPermutations<T>(IList<T> list, 
                                                      int? resultSize, 
                                                      bool withRepetition)
    {
    	if (list == null)
    	{
    		throw new ArgumentNullException("Source list is null.");
    	}
                
        if (resultSize.HasValue && resultSize.Value <= 0)
    	{
    		throw new ArgumentException("Result size must be any 
                                         number greater than zero.");
    	}
            
        var result = new T[resultSize.HasValue ? resultSize.Value : list.Count];
        var indices = new int[result.Length];
        for (int i = 0; i < indices.Length; i++)
    	{
    		indices[i] = withRepetition ? -1 : i - 1;
    	}
        
    	int curIndex = 0;
        while (curIndex != -1)
        {
        	indices[curIndex]++;
            if (indices[curIndex] == list.Count)
            {
            	indices[curIndex] = withRepetition ? -1 : curIndex - 1;
                curIndex--;
            }
            else
            {
            	result[curIndex] = list[indices[curIndex]];
                if (curIndex < indices.Length - 1)
    			{
    				curIndex++;
    			}
                else
    			{
    				yield return result;
    			}
                        
            }
        }
    }
