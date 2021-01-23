        //CellPainting event handler to draw image on cell
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1 && e.Value != null)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.DrawImage(Properties.Resources.YourIMAGE, new Rectangle(e.CellBounds.Left, e.CellBounds.Top + 2, e.CellBounds.Height - 4, e.CellBounds.Height - 4));
                StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center };
                e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, new SolidBrush(e.CellStyle.ForeColor), new Rectangle(e.CellBounds.Left + e.CellBounds.Height, e.CellBounds.Top, e.CellBounds.Width - e.CellBounds.Height, e.CellBounds.Height), sf);                
            }
        }
        bool imageClicked;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           CheckIfClickOnImage(e);
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CheckIfClickOnImage(e);
        }
        private void CheckIfClickOnImage(DataGridViewCellMouseEventArgs e){
           Rectangle rect = dataGridView1[e.ColumnIndex, e.RowIndex].ContentBounds;
            rect.Offset(-rect.Width + rect.Height + 4, 2);
            rect.Location.Offset(0, 2);
            System.Diagnostics.Debug.Print(e.Location.ToString());
            if (rect.Contains(e.Location))
            {
                imageClicked = true;
                MessageBox.Show(string.Format("You clicked on the image of the cell({0},{1})", e.ColumnIndex, e.RowIndex));
            }
        }
        //Clicking on a cell sometimes makes the clicked cell be in edit mode. So we can avoid this using some kind of flag
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (imageClicked)
            {
                e.Cancel = true;
                imageClicked = false;
            }
        }
