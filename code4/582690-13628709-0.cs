    using System.Collections;
    using System.Collections.Generic;
    public class EnumerableTestString : IEnumerable<string>
    {
        private IEnumerable<string> data;
    
        public EnumerableTestString(IEnumerable<string> d)
        {
            data = d;
        }
    
        public IEnumerator<string> GetEnumerator()
        {
            foreach (string s in data)
            {
                yield return s;
            }
        }
        // Explicit interface implementation for non-generic IEnumerable
        public IEnumerator IEnumerable.GetEnumerator()
        {
            // Delegate to the generic version
            return GetEnumerator();
        }
    }
