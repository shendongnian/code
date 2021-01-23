<pre>
    public class Infinitable<T> : IEnumerable<T>
    {
        private IEnumerable<T> enumerable;
        private bool isInfinite;
        public Infinitable(IEnumerable<T> enumerable)
        {
            this.enumerable = enumerable;
            this.isInfinite = false;
        }
        public Infinitable()
        {
            this.isInfinite = true;
        }
        public bool IsInfinite { get { return isInfinite; } }
        public IEnumerator<T> GetEnumerator()
        {
            if (isInfinite)
            {
                throw new InvalidOperationException(
                    "The enumerable cannot be enumerated");
            }
                
            return this.enumerable.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            if (isInfinite)
            {
                throw new InvalidOperationException(
                     "The enumerable cannot be enumerated");
            }
                
            return this.enumerable.GetEnumerator();
        }
    }
    // Sample usage.
    Infinitable<int> enumerable = GetEnumerable();
            
    if (enumerable.IsInfinite)
    {
        // This is 'infinite' enumerable.
    }
    else
    {
        // enumerate it here.
        foreach (var i in enumerable)
        {
        }
    }
</pre>
