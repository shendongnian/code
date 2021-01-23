    public class ByteArrayComparable : IComparable
    {
        public byte[] Data { get; private set; }
        public ByteArrayComparable(byte[] data) { Data = data; }
        // Implement IComparable.Compare() method here!
        public int CompareTo(object obj) { ... }
    }
    public class ToPos : MockResponseObject<IComparable>
    {
        public new byte[] Content
        {
            get
            {
                if (base.Content == null)
                    return null;
                return ((ByteArrayComparable) base.Content).Data;
            }
            set
            {
                base.Content = value == null ? null : new ByteArrayComparable(value);
            }
        }
    }
