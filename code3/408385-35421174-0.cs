        private void ChangeColumnType(System.Data.DataTable dt, string p, Type type){
                dt.Columns.Add(p + "_new", type);
                foreach (System.Data.DataRow dr in dt.Rows)
                {   // Will need switch Case for others if Date is not the only one.
                    dr[p + "_new"] =DateTime.FromOADate(double.Parse(dr[p].ToString())); // dr[p].ToString();
                }
                dt.Columns.Remove(p);
                dt.Columns[p + "_new"].ColumnName = p;
            }
    
