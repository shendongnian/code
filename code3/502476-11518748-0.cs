    public class MyList<T> : List<T>
    {
        public T Last
        {
            get
            {
                 return this[this.Count - 1];
            }
        }
    }
