    private void UpdateTheDataGrid() {
      DataTable vehicle = (DataTable)dataGrid1.DataSource;
      // vehicle.Rows[0].BeginEdit(); <- Unsure if this is even needed
      vehicle.Rows[0].ItemArray[0] = "TEST COMPLETE";            
      // vehicle.Rows[0].EndEdit();
      vehicle.AcceptChanges();
      dataGrid1.DataSource = vehicle;
    }
