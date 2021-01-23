    public class ListWithPrimary<T> : List<T> {
        public bool HasPrimary { get; private set; }
        private T primary;
        public T Primary
        {
            get
            {
                return primary;
            }
            set
            {
                if (!Contains(value)) throw new Exception();
                primary = value;
            }
        }
        public void AddPrimary(T item)
        { 
            Add(item);
            primary = item;
            HasPrimary = true;
        }
        public void ClearPrimary() {
            primary = default(T);
            HasPrimary = false;
        }
    }
