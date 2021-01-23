    public class StringHolder
    {
        public readonly Dictionary<string, string> Values = new Dictionary<string, string>();
        public override string ToString()
        {
            return this.ToString(Environment.NewLine);
        }
        public string ToString(string separator)
        {
            return string.Join(separator, this.Values.Select(kvp => string.Format("{0}: {1}", kvp.Key, kvp.Value)));
        }
        public string this[string key]
        {
            get { return this.Values[key]; }
            set { this.Values[key] = value; }
        }
    }
