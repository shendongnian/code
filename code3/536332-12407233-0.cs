    class Table
    {
        private Column[] columns;
        public Column Columns[int index]
        {
            get
            {
                return columns[index];
            }
        }
    }
    class Column
    {
        public string ColumnName
        {
            get;
            set;
        }
    }
