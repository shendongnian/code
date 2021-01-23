     var dtCopyTo = new DataTable();
     foreach(var rowCopyFrom in dtCopyFrom.Rows)
     {
       var newDataRow = dtCopyTo.NewRow();
       newDataRow.ItemArray = rowCopyFrom.ItemArray;
       dtCopyTo.AddRow(newDataTow);
     }
