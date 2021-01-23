    List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };
    list.OrderBy(n => n, new IntComparer(4));
    public class IntComparer : IComparer<int>
    {
    
        int start; 
    
        public IntComparer (int start)
        {
            this.start = start;
        }
    
        // Compares by Height, Length, and Width. 
        public int Compare(int x, int y)
        {
            if (x > start && y < start)
                // X is greater than Y
                return 1;
            else if (x < start && y > start)
                // Y is greater than X
                return -1;
            else if (x == y)
                return 0;
            else 
                return x > y ? 1 : -1;
        }
    } 
