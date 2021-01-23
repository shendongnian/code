        frm_MouseOverPicture HoverZoom = new frm_MouseOverPicture();
        private void dgv_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
           DataGridView dgv_sender = sender as DataGridView;
           DataGridViewCell dgv_MouseOverCell = dgv_sender.Rows[e.RowIndex].Cells[e.ColumnIndex];
           //Get FilePath from dgv_MouseOverCell content
           //Get x, y based on position relative to edge of screen
           //x, y = top left point of HoverZoom form
           HoverZoom.LoadPicture(FilePath);
           HoverZoom.Location = new System.Drawing.Point(x, y);
           HoverZoom.Show();
        }
        private void dgv_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
           HoverZoom.Hide();
           HoverZoom.ClearPicture();
        }
