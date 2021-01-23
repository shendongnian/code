    /// <summary>
    /// Returns -1 instead of 1 if y is IsNullOrEmpty when x is Not.
    /// </summary>
    public class EmptyStringsAreLast : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (String.IsNullOrEmpty(y) && !String.IsNullOrEmpty(x))
            {
                return -1;
            }
            else
            {
                return String.Compare(x, y);
            }
        }
     }
    
