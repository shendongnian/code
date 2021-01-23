    private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        Font bold = new System.Drawing.Font(this.DataGridView.Font, FontStyle.Bold);
        DataGridViewCellStyle style = null;
    
        foreach (DataGridViewRow row in this.DataGridView.Rows)
        {
            FlattenedResult item = row.DataBoundItem as FlattenedResult;
    
            if (item != null)
            {
                if (item.ParentID.Equals(item.ID))
                {
                    if (style == null)
                    {
                        style = new DataGridViewCellStyle(row.InheritedStyle);
                        style.Font = bold;
                    }
    
                    row.DefaultCellStyle = style;
                }
            }
        }
    }
