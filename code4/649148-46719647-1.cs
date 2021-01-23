    for (int = 0; i < yourDataTable.Rows.Count; i++)
    {
        DataRow row = yourDataTable.Rows[i];
        TableItem ti = new TableItem 
        { 
            Column1 = row["Column1Name"].ToString(), 
            Column2 = row["Column2Name"].ToString()
        }
        yourObservableCollection.Add(ti);
    }
    ObservableCollectionInViewModel = yourObservableCollection;
    
