    public sealed class MicroPool<T> where T : class
    {
        readonly T[] array;
        public MicroPool(int length = 10)
        {
            if (length <= 0) throw new ArgumentOutOfRangeException("length");
            array = new T[length];
        }
        public T TryGet()
        {
            T item;
            for (int i = 0; i < array.Length; i++)
            {
                if ((item = Interlocked.Exchange(ref array[i], null)) != null)
                    return item;
            }
            return null;
        }
        public void Recycle(T item)
        {
            if(item == null) return;
            for (int i = 0; i < array.Length; i++)
            {
                if (Interlocked.CompareExchange(ref array[i], item, null) == null)
                    return;
            }
            using (item as IDisposable) { } // cleaup if needed
        }
    }
