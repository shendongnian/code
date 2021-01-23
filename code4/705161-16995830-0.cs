     private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                e.Handled = true;
                e.Graphics.FillRectangle(Brushes.Green, e.CellBounds);
                StringFormat sf = new StringFormat(){Alignment=StringAlignment.Center, LineAlignment = StringAlignment.Center };
                Font f = new Font(e.CellStyle.Font, FontStyle.Underline);
                e.Graphics.DrawString(e.Value.ToString(), f, new SolidBrush(e.CellStyle.ForeColor), e.CellBounds, sf);
            }
        } 
