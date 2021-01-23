     interface ITable
    {
        DataRow Select(int id);
        IEnumerable<DataRow> Select(List<int> ids);
        int Insert(DataRow t);
        void Update(DataRow t);
        
    }
    interface ITable<T>  where T : DataRow, new()
    {
        T Select(int id);
        List<T> Select(List<int> ids);
        int Insert(T t);
        void Update(T t);
        bool Delete(int id);
    }
    class Table<T> : ITable<T>, ITable where T : DataRow, new()
    {
        public T Select(int id)
        {
            return new T();
        }
        public List<T> Select(List<int> ids)
        {
            return new List<T>();
        }
        public int Insert(T t)
        {
            return 1;
        }
        public void Update(T t)
        {
        }
        public bool Delete(int id)
        {
            return true;
        }
        DataRow ITable.Select(int id)
        {
            return this.Select(id);
        }
        IEnumerable<DataRow> ITable.Select(List<int> ids)
        {
            return this.Select(ids);
        }
        public int Insert(DataRow t)
        {
            return this.Insert(t);
        }
        public void Update(DataRow t)
        {
            this.Update(t);
        }
    }
