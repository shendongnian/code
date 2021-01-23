    public class MyKeyValuePair
    {
        private readonly KeyValuePair<string, int> myKeyValuePair;
        public MyKeyValuePair(string key, int value)
        {
            myKeyValuePair = new KeyValuePair<string, int>(key, value);
        }
        public string Key { get { return myKeyValuePair.Key; } }
        public int Value { get { return myKeyValuePair.Value; } }
        public static bool operator ==(MyKeyValuePair a, MyKeyValuePair b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            return a.Key.Equals(b.Key, StringComparison.OrdinalIgnoreCase);
        }
        public static bool operator !=(MyKeyValuePair a, MyKeyValuePair b)
        {
            return !(a == b);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            MyKeyValuePair p = obj as MyKeyValuePair;
            if ((object)p == null)
            {
                return false;
            }
            return this.Key == p.Key;
        }
        public bool Equals(MyKeyValuePair obj)
        {
            if ((object)obj == null)
            {
                return false;
            }
            return this.Key.Equals(obj.Key, StringComparison.OrdinalIgnoreCase);
        }
        public override int GetHashCode()
        {
            return this.Key.ToUpperInvariant().GetHashCode();
        }
    }
