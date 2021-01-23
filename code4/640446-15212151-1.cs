    namespace TestCStyleArrays
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			{
    				var center = Tuple.Create(0f, 1f, 2f);
    				var extents = Tuple.Create(10f, 20f, 30f);
    				var nearestPt = Tuple.Create(0f, 0f, 0f);
    				CStyleArrays.Poly.FindNearest(center, extents, out nearestPt);
    			}
    
    			{
    				var center = new[] { 0f, 1f, 2f };
    				var extents = new[] { 10f, 20f, 30f };
    				var nearestPt = new[] { 0f, 0f, 0f };
    				CStyleArrays.Poly.FindNearest(center, extents, out nearestPt);
    			}
    		}
    	}
    }
