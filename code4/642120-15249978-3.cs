    pubilc void BindGrid()
    {
        tempDt.Clear();
        for(int i=(currentPage*pageSize);i<(currentPage*pageSize)+pageSize; i++)
        {
            DataRow row =  tempDt.NewRow();
           foreach(DataColumn col in tempDt.Columns)
           {
              row[col] = selectedFieldsTable.Rows[i][col];
           } 
           tempDt.Rows.Add(row); 
        }
        dgvSelectedFieldsView.DataSource = tempDt;   
    }
