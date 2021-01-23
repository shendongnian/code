    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.Value == null)
            return;
        var s = e.Graphics.MeasureString(e.Value.ToString(), dataGridView1.Font);
        if (s.Width > dataGridView1.Columns[e.ColumnIndex].Width)
        {
            using (
      Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor),
      backColorBrush = new SolidBrush(e.CellStyle.BackColor))
            {
                e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                e.Graphics.DrawString(e.Value.ToString(), dataGridView1.Font, Brushes.Black, e.CellBounds, StringFormat.GenericDefault);
                dataGridView1.Rows[e.RowIndex].Height = (int)(s.Height * Math.Ceiling(s.Width / dataGridView1.Columns[e.ColumnIndex].Width));
                e.Handled = true;
            }
        }
    }
