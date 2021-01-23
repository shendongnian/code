    public class MyString : IComparable, IComparable<string>, IEnumerable<char>, IEnumerable, IEquatable<string>
    {
        #region Static Operators
        public static implicit operator MyString(string value)
        {
            return new MyString(value);
        }
        public static implicit operator string(MyString value)
        {
            return value.value;
        }
        public static bool operator !=(MyString a, MyString b)
        {
            return a.value != b.value;
        }
        public static bool operator ==(MyString a, MyString b)
        {
            return a.value == b.value;
        }
        public static bool operator !=(MyString a, string b)
        {
            return a.value != b;
        }
        public static bool operator ==(MyString a, string b)
        {
            return a.value == b;
        }
        public static bool operator !=(string a, MyString b)
        {
            return a != b.value;
        }
        public static bool operator ==(string a, MyString b)
        {
            return a == b.value;
        }
        #endregion
        private string value;
        public int Length
        {
            get { return (value != null) ? value.Length : 0; }
        }
        public MyString(string value)
        {
            this.value = PciCleaner.Clean(value);
        }
        #region Object Overrides
        public override string ToString()
        {
            return value;
        }
        public override bool Equals(object obj)
        {
            return (value != null) ? value.Equals(obj) : false;
        }
        public override int GetHashCode()
        {
            return (value != null) ? value.GetHashCode() : new object().GetHashCode();
        }
        #endregion
        #region IComparable
        public int CompareTo(object obj)
        {
            return (value != null) ? value.CompareTo(obj) : -1;
        }
        #endregion
        #region IComparable<string>
        public int CompareTo(string other)
        {
            return (value != null) ? value.CompareTo(other) : -1;
        }
        #endregion
        #region IEnumerable<char>
        public IEnumerator<char> GetEnumerator()
        {
            return (value != null) ? value.GetEnumerator() : null;
        }
        #endregion
        #region IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (value != null) ? (value as IEnumerable).GetEnumerator() : null;
        }
        #endregion
        #region IEquatable<string>
        public bool Equals(string other)
        {
            return (value != null) ? value.Equals(other) : false;
        }
        #endregion
    }
