    public class StringData : IEnumerable<string>
    {
        ...
        #region IEnumerable<string> Members
        public IEnumerator<string> GetEnumerator()
        {
            foreach (string s in data) {
                yield return s;
            }
        }
        #endregion
        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();  // Calls generic GetEnumerator
        }
        #endregion
    }
