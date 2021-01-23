            //  get the Current state of the data
            DataTable dtCurrent = MyMethod.GetCurrentData();
            //  get the Last uploaded data
            DataTable dtLast = MyMethod.GetLastUploadData();
            dtLast.AcceptChanges();
            //  the table meant to hold only the differences
            DataTable dtChanges = null;
            //  merge the Current DataTable into the Last DataTable, 
            //  with preserve changes set to TRUE
            dtLast.Merge(dtCurrent, true);
            //  invoke GetChanges() with DataRowState.Unchanged
            //    !! this is the key !!
            //    the rows with RowState == DataRowState.Unchanged 
            //    are the differences between the 2 tables
            dtChanges = dtLast.GetChanges(DataRowState.Unchanged);
