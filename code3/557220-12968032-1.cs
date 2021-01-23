    foreach(DataGridViewColumn col in dgvBreakDowns.Columns)
    {
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
    }
