    public class KeyVal<Key, Val>
    {
        public Key Id { get; set; }
        public Val Text { get; set; }
        public KeyVal() { }
        public KeyVal(Key key, Val val)
        {
            this.Id = key;
            this.Text = val;
        }
    }
