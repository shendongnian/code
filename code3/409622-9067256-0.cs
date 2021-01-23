    public class IntArrayComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] i1, int[] i2)
        {
            if(ReferenceEquals(i1, i2))
            {
                return true;
            }
            else if(i1 == null || i2 == null)
            {
                return false;
            }
            else if(i1.Length != i2.Length)
            {
                return false;
            }
            for(int i = 0; i < i1.Length; ++i)
            {
                if(i1[i] != i2[i]) return false;
            }
            return true;
        }
        public int GetHashCode(int[] obj)
        {
            // Average is probably not the best hash for an int array,
            // but I'm lazy right now and this is only for demonstration purposes
            return obj != null ? (int)obj.Average() : 0;
        }
    }
