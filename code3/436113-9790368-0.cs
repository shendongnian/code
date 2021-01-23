    private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dgv.Columns[e.ColumnIndex].Name == "status")
        {
            if (e.Value != null)
            {
                if (e.Value.ToString() == "1")
                {
                    e.Value = imageList1.Images[1];
                }
                else
                {
                    e.Value = imageList1.Images[2];
                }
            }
        }
    }
