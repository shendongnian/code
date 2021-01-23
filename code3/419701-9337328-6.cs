    public class Table<T, PK>
        where T : IRecord<PK>
    {
        private Dictionary<PK, T> _table = new Dictionary<PK, T>();
        public void Add(T item)
        {
            _table.Add(item.ID, item);
        }
    }
