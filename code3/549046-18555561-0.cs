    /// <summary>
    /// Used to create custom comparers on the fly
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericCompare<T> : IComparer<T>
    {
        // Function use to perform the compare
        private Func<T, T, int> ComparerFunction { set; get; }
        // Constructor
        public GenericCompare(Func<T, T, int> comparerFunction)
        {
            ComparerFunction = comparerFunction;
        }
        // Execute the compare
        public int Compare(T x, T y)
        {
            
            if (x == null || y == null) 
            {
                // These 3 are bell and whistles to handle cases where one of the two is null, to sort to top or bottom respectivly
                if (y == null && x == null) { return 0; }
                if (y == null) { return 1; }
                if (x == null) { return -1; }
            }
            try
            {
                // Do the actual compare
                return ComparerFunction(x, y);
            }
            catch (Exception ex)
            {
                // But muffle any errors
                System.Diagnostics.Debug.WriteLine(ex);
            }
            // Oh crud, we shouldn't be here, but just in case we got an exception.
            return 0;
        }
    }
