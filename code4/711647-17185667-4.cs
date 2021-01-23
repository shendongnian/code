    private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.DrawImage(Properties.Resources.yourIMAGE, new Rectangle(e.CellBounds.Left + 5, e.CellBounds.Top + 5, e.CellBounds.Width - 10, e.CellBounds.Height - 10));                    
            }
    }
    //To handle the click on a Row header, you can add custom code to a RowHeaderMouseClick event handler
    private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
       MessageBox.Show(e.RowIndex.ToString());
    }
