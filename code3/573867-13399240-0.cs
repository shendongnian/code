    public class ComparableString : IComparable
    {
        public Int64 Key { get; set; }
        public string Value { get; set; }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            string otherString = obj as ComparableString;
            if (otherString != null)
            {
                // PLACE YOUR COMPARE LOGIC HERE
                return this.Value.CompareTo(otherString.Value);
            }
            else
            {
                throw new ArgumentException("Object is not a Comparable String");
            }
        }
    }
