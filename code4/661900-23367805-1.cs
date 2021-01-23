    private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        DataGridViewCellStyle style = new DataGridViewCellStyle(this.DataGridView.RowsDefaultCellStyle);
        style.Font = new System.Drawing.Font(this.DataGridView.Font, FontStyle.Bold);
        
        foreach (DataGridViewRow row in this.DataGridView.Rows)
        {
            FlattenedResult item = row.DataBoundItem as FlattenedResult;
    
            if (item != null)
            {
                if (item.ParentID.Equals(item.ID))
                    row.DefaultCellStyle = style;
            }
        }
    }
