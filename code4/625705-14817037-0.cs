    private static void PrintEachItemInList<X, T>(X anyType) where X:System.Collections.Generic.List<T>
    {
    
    			 foreach (var t in anyType)
    			{
    				Console.WriteLine(t.ToString());
    			}
    }
