    // implementation:
    public class ReverseSort : IComparer
    {
        public int Compare(object x, object y)
        {
            // reverse the arguments
            return Comparer.Default.Compare(y, x);
        }    
    }
