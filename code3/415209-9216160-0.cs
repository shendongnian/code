    while (vysledky.Read())
    {
        // Iterate over each of the fields (columns) in the datareader's current record
        for (int i = 0; i < vysledky.FieldCount; i++)
        {
            var value = vysledky[i];
            TableCell cell = new TableCell(); 
            cell.Text = Convert.ToString(value); 
            row.Controls.Add(cell); 
        }
    }
