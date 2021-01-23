            DataRow dRow = dataTable.NewRow();
            //...
            DataRowView dRowView = dRow.Table.DefaultView.AddNew();
            for (int i = 0; i < dRow.ItemArray.Length; i++)
            {
                dRowView.Row[i] = dRow[i];
            }
