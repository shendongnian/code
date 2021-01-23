    public class MyDataStructure<T>//TODO come up with better name
    {
        private Dictionary<string, int> columns;
        private Dictionary<string, int> rows;
        private List<List<T>> data;
        public MyDataStructure(
                IEnumerable<string> rows,
                IEnumerable<string> columns)
        {
            this.columns = columns.Select((name, index) => new { name, index })
                .ToDictionary(x => x.name, x => x.index);
            this.rows = rows.Select((name, index) => new { name, index })
                .ToDictionary(x => x.name, x => x.index);
            initData();
        }
        private void initData()
        {
            data = new List<List<T>>(rows.Count);
            for (int i = 0; i < rows.Count; i++)
            {
                data.Add(new List<T>(columns.Count));
                for (int j = 0; j < columns.Count; j++)
                {
                    data[i].Add(default(T));
                }
            }
        }
        public T this[string row, string column]
        {
            //TODO error checking for invalid row/column values
            get
            {
                return data[rows[row]][columns[column]];
            }
            set
            {
                data[rows[row]][columns[column]] = value;
            }
        }
        public void AddColumn(string column)
        {
            columns.Add(column, columns.Count);
            for (int i = 0; i < data.Count; i++)
            {
                data[i].Add(default(T));
            }
        }
        public void AddRow(string row)
        {
            rows.Add(row, rows.Count);
            var list = new List<T>(columns.Count);
            data.Add(list);
            for (int i = 0; i < columns.Count; i++)
            {
                list.Add(default(T));
            }
        }
        public bool RenameRow(string oldRow, string newRow)
        {
            if (rows.ContainsKey(oldRow) && !rows.ContainsKey(newRow))
            {
                this.Add(newRow, rows[oldRow]);
                this.Remove(oldRow);
                return true;
            }
            return false;
        }
    }
