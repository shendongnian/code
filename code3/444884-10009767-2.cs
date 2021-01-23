    Datatable newTable =  new DataTable();
    
                foreach(string s1 in list)
                {
                    if (s1 != string.Empty) {
                        dvProducts.RowFilter = "(CODE like '" + serachText + "*') AND (CODE <> '" + s1 + "')";
                        foreach(DataRow dr in dvProducts.ToTable().Rows)
                        {
                           newTable.ImportRow(dr);
                        }
                    }
                }
    ListView1.DataSource = newTable;
    ListView1.DataBind();
