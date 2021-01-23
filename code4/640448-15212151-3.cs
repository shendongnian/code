    namespace TestCStyleArrays
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			{
    				var center = Tuple.Create(0f, 1f, 2f);
    				var extents = Tuple.Create(10f, 20f, 30f);
    				Tuple<float, float, float> nearestPt;
    				CStyleArrays.Poly.FindNearest(center, extents, out nearestPt);
    			}
    
    			{
    				var center = new[] { 0f, 1f, 2f };
    				var extents = new[] { 10f, 20f, 30f };
    				var nearestPt = new float[3];
    				CStyleArrays.Poly.FindNearest(center, extents, ref nearestPt);
    			}
    		}
    	}
    }
