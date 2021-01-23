    public class MyList<T> : List<T>
    {
        public T Last
        {
            get
            {
                return this[this.Count - 1];
            }
            set
            {
                this[this.Count - 1] = value;
            }
        }
    }
