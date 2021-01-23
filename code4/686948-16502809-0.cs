    public class Entry<T> : IComparable<T>, IEquatable<T>
    {
        public int CompareTo(T other)
        {
            //compare logic... 
        }
        public bool Equals(T other)
        {
            return CompareTo(other) == 0;
        }
    }
