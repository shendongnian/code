    // ...
    if(pRow.RowState != DataRowState.Deleted)
    {
        var row = myData.xspArea.FindByxar_Id(pRow.xar_Id);
        if (row.RowState != DataRowState.Deleted)
        {
            row.Delete();
            // ...
        }
    // ...
