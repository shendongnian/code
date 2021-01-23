    public static class Extensions
    {
        public static T[] Slice<T>(this T[] source, int index, int length)
        {       
            T[] slice = new T[length];
            Array.Copy(source, index, slice, 0, length);
            return slice;
        }
    }
