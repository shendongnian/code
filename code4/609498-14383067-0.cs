    this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
    this.dataGridView1.AllowUserToResizeRows = false;
    this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
     private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        if (e.RowIndex == -1) return;
        // Calculate the bounds of the row.
        Rectangle rowBounds = new Rectangle(
            this.dataGridView1.RowHeadersWidth, e.RowBounds.Top,
            this.dataGridView1.Columns.GetColumnsWidth(
                DataGridViewElementStates.Visible) -
            this.dataGridView1.HorizontalScrollingOffset + 1,
            e.RowBounds.Height);
        // Paint the custom background. 
        using (Brush backbrush =
           new SolidBrush(this.dataGridView1.GridColor), backColorBrush = new SolidBrush(Color.White))
        {
            using (Pen gridLinePen = new Pen(backbrush))
            {
                //Apply to spicific row
                if (e.RowIndex == 2)
                {
                    e.Graphics.FillRectangle(backbrush, rowBounds);
                    // Draw the inset highlight box.
                    e.Graphics.DrawRectangle(Pens.Blue, rowBounds);
                }
            }
        }
    }
    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex == -1) return;
        if (e.Value != null)
        {
            // Draw the text content of the cell, ignoring alignment of e.RowIndex != 2
            if (e.RowIndex != 2)
            {
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
               Brushes.Black, e.CellBounds.X + 2,
               e.CellBounds.Y + 2, StringFormat.GenericDefault);
            }
        }
        e.Handled = true;
    }
