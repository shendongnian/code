       foreach(DataRow dr in list)
        {
            newRow = tempTable.NewRow();
            newRow["Field Name"] = dr.ItemArray[0].ToString();
            newRow["Field Type"] = dr.ItemArray[1].ToString();
            tempTable.Rows.Add(newRow);
            tempTable.AcceptChanges();
        }
