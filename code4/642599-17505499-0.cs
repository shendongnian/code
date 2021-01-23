    myTable.GetChanges(); // Return Any of Chnages Made without applying myTable.Accepchanges()
    myTable.GetChanges(DataRowState.Added); // Return added rows without applying myTable.Accepchanges()
    myTable.GetChanges(DataRowState.Deleted); 
    myTable.GetChanges(DataRowState.Detached);
    myTable.GetChanges(DataRowState.Modified);
    myTable.GetChanges(DataRowState.Unchanged);
