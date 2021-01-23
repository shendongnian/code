    public class MyList<T> : List<T>
    {
        private FieldInfo _items = 
             typeof(List<T>)
             .GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance);
        public T[] Items
        {
            get
            { 
                return (T[])_items.GetValue(this);
            }
        }
    }
