    public class EnumerableTestString : System.Collections.Generic.IEnumerable<string>
    {
        System.Collections.Generic.IEnumerable<string> data;
        public EnumerableTestString(System.Collections.Generic.IEnumerable<string> d)
        {
            data = d;
        }
        public System.Collections.Generic.IEnumerator<string> GetEnumerator()
        {
            foreach (string s in data)
            {
                yield return s;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
