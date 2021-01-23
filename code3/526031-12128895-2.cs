    for(int x = 0; x < datatable.Rows.Count; x++)
    {
       DataRow r = dataTable.Rows[x];
       if(r.RowState == DataRowState.Deleted)
       {
           r.RejectChanges();
           .... //do you stuff
           r.Delete(); // redelete the row,
       }
    }
