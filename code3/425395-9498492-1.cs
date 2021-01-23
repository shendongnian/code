    private void grd_MouseClick(object sender, MouseEventArgs e)
    {
        try
        {
            if (e.Button == MouseButtons.Right)
            {
               DataGridView.HitTestInfo h =  grd.HitTest(e.X, e.Y);
               if (h != null && h.RowIndex >= 0 && h.ColumnIndex >= 0)
               {
                   grd.CurrentCell = grd[h.ColumnIndex, h.RowIndex];
                   grd.ContextMenuStrip.Show(grd, e.Location);
               }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
