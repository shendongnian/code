    private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
            if (e.ColumnIndex > -1&&e.RowIndex > -1&&dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {                
                if (e.Value == null) return;
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);
                e.PaintContent(e.CellBounds);
                //prepare format for drawing string yourself.
                StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
                e.Graphics.DrawString(((Button)e.Value).Text, dataGridView.Font, Brushes.Black, e.CellBounds, sf);                
            }
    }
