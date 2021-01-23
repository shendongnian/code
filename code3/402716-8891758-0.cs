    if(dataSet.HasChanges(DataRowState.Modified | 
            DataRowState.Added)&& dataSet.HasErrors)
        {
            // Use GetChanges to extract subset.
            changesDataSet = dataSet.GetChanges(
                DataRowState.Modified|DataRowState.Added);
            PrintValues(changesDataSet, "Subset values");
    
            // Insert code to reconcile errors. In this case, reject changes.
            foreach(DataTable changesTable in changesDataSet.Tables)
            {
                if (changesTable.HasErrors)
                {
                    foreach(DataRow changesRow in changesTable.Rows)
                    {
                        //Console.WriteLine(changesRow["Item"]);
                        if((int)changesRow["Item",DataRowVersion.Current ]> 100)
                        {
                            changesRow.RejectChanges();
                            changesRow.ClearErrors();
                        }
                    }
                }
            }
            // Add a column to the changesDataSet.
            changesDataSet.Tables["Items"].Columns.Add(
                new DataColumn("newColumn"));
            PrintValues(changesDataSet, "Reconciled subset values");
            // Merge changes back to first DataSet.
            dataSet.Merge(changesDataSet, false, 
                System.Data.MissingSchemaAction.Add);
        }
        PrintValues(dataSet, "Merged Values");
