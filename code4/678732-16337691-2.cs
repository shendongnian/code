        public static DataTable Sort(this DataTable dt, string ColumnName, string param)
        {
            DataTable dtCopy = new DataTable();
            List<DataRow> list = dt.Rows.Cast<DataRow>().ToList();
            list.Sort((x, y) => Convert.ToString(x[ColumnName]).ToLower().IndexOf(param).CompareTo(Convert.ToString(y[ColumnName]).ToLower().IndexOf(param)));
            dtCopy = list.CopyToDataTable();
            return dtCopy;
        }
     this will sort the Data with the filter parameter(in your case "na")
    
        //ColumnName is EmployeeName In your Case and filter text is txtSearchValue.Text   
        DataTable dt2 = table.Sort("ColumnName", txtSearchValue.Text); 
        DataView dv = dt2.DefaultView;
