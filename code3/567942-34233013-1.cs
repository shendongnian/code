    foreach (DataGridViewRow item in DGDoc.Rows)
    {
        if (item.Cells[0].Value == null)
            item.Cells[0].Value = "True";
        if (bool.Parse(item.Cells[0].Value.ToString()))
        {
            item.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(241, 215, 215);
            strIDs += "," + item.Cells[1].Value.ToString();
            intSumPrice += Int64.Parse(item.Cells[4].Value.ToString());
            intSumTax += Int64.Parse(item.Cells[5].Value.ToString());
            intSumPay += Int64.Parse(item.Cells[6].Value.ToString());
        }
        else
        {
            item.DefaultCellStyle.BackColor = System.Drawing.Color.Empty;
        }
    }
    DGDoc.EndEdit();
