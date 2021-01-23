    decimal sum = 0.0m;
    decimal product = 0;
    
    for (int i = 0; i < gridProizvodi.Rows.Count; i++)
    {
        DataGridViewRow row = gridProizvodi.Rows[i];
        if (row.IsNewRow) break;
        product = row.Cells("Price").Value * row.Cells("Amount").Value;
        '--- if your price and amount field is numeric type, you dont have to convert it
    
        sum += product;
        row.Cells("Total").Value = product;
    }
