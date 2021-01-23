    public class BoolArrayKey
    {
        private int hash;
        private bool[] data;
        public BoolArrayKey(bool[] source)
        {
            data = new bool[source.Length];
            Array.Copy(source, data, source.Length);
        }
        public override bool Equals(object obj)
        {
            BoolArrayKey other = obj as BoolArrayKey;
            if (other == null)
            {
                return false;
            }
            return other.data.SequenceEqual(data);
        }
        public override int HashCode()
        {
            if (hash == 0)
            {
                // Mark's hash implementation here, store the result in `hash`.
            }
            return hash;    
        }
    }
