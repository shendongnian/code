    public void BindAutoCompleteList(DataTable myDataTable)
    {
         AutoCompleteStringCollection acDataSource= new  
         AutoCompleteStringCollection();
         foreach (DataRow row in myDataTable.Rows)
          {
             acDataSource.Add(row.Cells[0].Value.ToString());
          }
        
                   
         txtBoxAuto.Clear(); 
         txtBoxAuto.AutoCompleteMode = AutoCompleteMode.Suggest;
         txtBoxAuto.AutoCompleteSource = AutoCompleteSource.CustomSource;
         txtBoxAuto.AutoCompleteCustomSource = acDataSource;
    }
