        public static DataTable ToDataTable(List<string> list)
        {
            DataTable MethodResult = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("Item", );
            foreach(string s in list)
            {
                DataRow dr = dt.NewRow();
                dr[0] = s;
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();
            MethodResult = dt;
            return MethodResult;
        }
