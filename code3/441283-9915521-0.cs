    public class Range<T> where T : IComparable<T>
    {
        ...
        public bool Check(T value)
        {
            return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
        }
    }
