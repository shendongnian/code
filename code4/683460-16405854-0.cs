    sealed class CountDuplicatesFastCaller
    {
        public int Call<T>(IList<T> list) where T : IComparable<T>
        {
            return CountDuplicatesFast(list);
        }
    }
    
    public static int CountDuplicates<T>(IList<T> list)
    {
        if (typeof (IComparable<T>).IsAssignableFrom(typeof (T)))
        {
            return ((dynamic) new CountDuplicatesFastCaller()).Call(list);
        }
        else
        {
            /* use the slow algorithm */
        }
    }
