    class Matrix<T>
    {
        readonly Dictionary<int, Dictionary<int, T>> _rows = new Dictionary<int, Dictionary<int, T>>();
    
        public T this[int i, int j]
        {
            get
            {
                var row = ExpandOrGet(j);
                if (!row.ContainsKey(i)) row[i] = default(T);
    
                UpdateSize(i, j);
    
                return row[i];
            }
            set
            {
                ExpandOrGet(j);
                _rows[j][i] = value;
    
                UpdateSize(i, j);
            }
        }
    
        void UpdateSize(int i, int j)
        {
            if (j > SizeRows) SizeRows = j;
            if (i > SizeColums) SizeColums = i;
        }
    
        public int SizeRows { get; private set; }
        public int SizeColums { get; private set; }
    
        Dictionary<int, T> ExpandOrGet(int j)
        {
            Dictionary<int, T> result = null;
    
            if (!_rows.ContainsKey(j))
            {
                result = new Dictionary<int, T>();
                _rows[j] = result;
            }
            else result = _rows[j];
    
            return result;
        }
    }
