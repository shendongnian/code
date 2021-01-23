    public class Position : IEnumerable<int>
    {
        private int[] _desk;
        public int this[int index]
        {
            get { return _desk[index]; }
            set { _desk[index] = value; }
        }
        /* the rest of your class */
        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>)_desk).GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _desk.GetEnumerator();
        }
    }
