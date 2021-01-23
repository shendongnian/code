    private void dgwParti_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if ((Rows[e.RowIndex].DataBoundItem as DeParti).Arti.Type == ArtiType.Fast
            && e.ColumnIndex == 8)
        {
             e.Value = "";
        }
    }
