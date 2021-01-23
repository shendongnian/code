    public int currentPage =0;
    public int totalPages=0;
    public int pageSize=5;
    public DataTable tempDt = new DataTable();
    public void LoadGrid()
    {
        //calculate the total number of pages..
        double result = (double)selectedFieldsTable.Rows.Count/pageSize;
        if(result>(selectedFieldsTable.Rows.Count/pageSize))
            ++result;
        totalPages = result;
    
          
             foreach (DataColumn col in selectedFieldsTable.Columns)
             {
                tempDt.Columns.Add(col);
             }
            BindGrid();
    }
