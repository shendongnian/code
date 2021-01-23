    public class MyCollection<T> : IEnumerable<T>
    {
        private T[] vector = new T[1000];
        public void Add(T elemento)
        {
            this.vector[vector.Length] = elemento;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return vector.Take(vector.Length).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
