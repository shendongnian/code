    public class Row
    {
        public Row()
        {
        }
        public Row(string key, int value)
        {
            Key = key;
            Value = value;
        }
        public int Value { get; set; }
        public string Key { get; set; }
    }
