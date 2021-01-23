    void Main()
    {
    	int[] numbers = { 1, 2, 3, 4, 5 };
    	var result = numbers.OrderBy(x=> x, new MyComparer()));
          // 1, 3, 5, 2, 4
    }
    
    public class MyComparer : IComparer<int>  
    {
        public int Compare( int x, int y)
        {
          return  x % 2 == y % 2 ? 0 : x % 2 == 1 ? -1 : 1;
        }
    }
