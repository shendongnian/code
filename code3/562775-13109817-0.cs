    public class SpecialArray<T> : IComparable<SpecialArray<T>>
        where T : IComparable
    {
        public T[] InternalArray { get; private set; }
        public SpecialArray(T[] array)
        {
            InternalArray = array;
        }
        public int CompareTo(SpecialArray<T> other)
        {
            int minLength = Math.Min(InternalArray.Length, other.InternalArray.Length);
            for ( int i = 0; i < minLength; i++ )
            {
                int result = InternalArray[i].CompareTo(other.InternalArray[i]);
                if ( result != 0 )
                    return result;
            }
            return 0;
        }
    }
