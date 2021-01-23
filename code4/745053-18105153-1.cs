    public class MyCollection<T> : IEnumerable<T>
    {
        private T[] vector = new T[1000];
        private int count;
        public void Add(T elemento)
        {
            this.vector[count++] = elemento;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return vector.Take(count).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
