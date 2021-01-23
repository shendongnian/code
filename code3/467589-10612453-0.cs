    switch (gridMode){
      case GridMode.Company:
       this.AddColumns(userColumnList);
       gridMode = GridMode.User;
       break;
      case GridMode.User:
       this.AddColumns(userColumnList);
       gridMode = GridMode.Company;
       break;
    }
    
    protected void AddColumns(List<Column> adds){
      extractDataGrid.Layout.Suspend();
      extractionDataGrid.Columns.Clear();
      foreach(Column c in adds){
       extractionDataGrid.Columns.Add(c); 
      }
    extractDataGrid.Layout.Resume();
    }
