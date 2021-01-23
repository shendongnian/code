    foreach (DataRow DRow in dtEquipment.Rows)
    {
        TableRow tRow = new TableRow();
        foreach (DataColumn dCol in dtEquipment.Columns)
        {
            // ...
            tCell.Text = DRow[dCol].ToString();
            // ...
        }
        tblTest.Rows.Add(tRow);
    }
