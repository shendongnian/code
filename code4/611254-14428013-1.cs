        public bool ValidateRecord(object value)
        { 
            return (value as int?) == 1;
        }
        public static DataTable GetItems()
        { 
            //generate some demo data...
            DataTable dt = new DataTable();
            dt.Columns.Add("RowState", typeof(int?));
            dt.Columns.Add("Id",typeof(int));
            dt.Columns.Add("col1", typeof(string));
            dt.Columns.Add("col2", typeof(string));
            dt.Columns.Add("col3", typeof(string));
            dt.Columns.Add("col4", typeof(string));
            dt.Columns.Add("col5", typeof(string));
            dt.Columns.Add("col6", typeof(string));
            dt.Columns.Add("col7", typeof(string));
            dt.Rows.Add(new object[] {1, 1,"some","data","in","first","row", ".", ".." });
            dt.Rows.Add(new object[] {0, 2, "second", "record", "inside", "demo", "datatable", "-", "--" });
            return dt;
        }
