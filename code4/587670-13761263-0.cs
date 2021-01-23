        DataTable table;
        public Form1()
        {
            InitializeComponent();
            #region TestData
            table = new DataTable();
            table.Clear();
            for (int i = 1; i < 12; ++i)
                table.Columns.Add("Col" + i);
            for (int rowIndex = 0; rowIndex < 5; ++rowIndex)
            {
                DataRow row = table.NewRow();
                for (int i = 0; i < table.Columns.Count; ++i)
                    row[i] = String.Format("row:{0},col:{1}", rowIndex, i);
                table.Rows.Add(row);
            }
            #endregion
            bind();
        }
        public void bind()
        {
            var filtered = from t in table.AsEnumerable()
                           select new
                           {
                               col1 = t.Field<string>(0),//column of index 0 = "Col1"
                               col2 = t.Field<string>(1),//column of index 1 = "Col2"
                               col3 = t.Field<string>(5),//column of index 5 = "Col6"
                               col4 = t.Field<string>(6),//column of index 6 = "Col7"
                               col5 = t.Field<string>(4),//column of index 4 = "Col3"
                           };
            filteredData.AutoGenerateColumns = true;
            filteredData.DataSource = filtered.ToList();
        }
    }
