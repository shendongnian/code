        private void dtSearch_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the cell that was clicked from the location of the mouse pointer
            DataGridView.HitTestInfo htiSelectedCell = dtSearch.HitTest(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
                // Make sure that a cell was clicked, and not the column or row headers
                // or the empty area outside the cells. If it is a cell,
                // then select the entire row, set the current cell (to move the arrow to
                // the current row)
                //if (htiSelectedCell.Type == DataGridViewHitTestType.Cell)
                if (htiSelectedCell.Type == DataGridViewHitTestType.RowHeader)
                {
                    // do stuff here
                }
            }
        }
