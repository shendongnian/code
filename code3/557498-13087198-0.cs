    private void dgwParti_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if ((Rows[e.RowIndex].DataBoundItem as DeParti).Arti.Type == ArtiType.Fast)
        {
             e.Value = "";
        }
    }
