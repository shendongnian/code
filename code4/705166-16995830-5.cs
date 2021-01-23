     Point spot;
     private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                e.Handled = true;
                if (e.CellBounds.Contains(spot))//Mouse over cell
                {
                    PaintCellBackground(e.Graphics, Color.Red, e.CellBounds);
                }
                else //Mouse leave cell
                {
                    PaintCellBackground(e.Graphics, Color.Green, e.CellBounds);
                }
                StringFormat sf = new StringFormat(){Alignment=StringAlignment.Center, LineAlignment = StringAlignment.Center };
                Font f = new Font(e.CellStyle.Font, FontStyle.Underline);
                e.Graphics.DrawString(e.Value.ToString(), f, new SolidBrush(e.CellStyle.ForeColor), e.CellBounds, sf);
            }
        } 
     private void PaintCellBackground(Graphics g, Color c, Rectangle rect)
        {
            Rectangle topHalf = new Rectangle(rect.Left, rect.Top, rect.Width, rect.Height / 2);
            Rectangle bottomHalf = new Rectangle(rect.Left, topHalf.Bottom, rect.Width, topHalf.Height);
            g.FillRectangle(new SolidBrush(Color.FromArgb(150, c)), topHalf);
            g.FillRectangle(new SolidBrush(c), bottomHalf);
            ControlPaint.DrawBorder(g, rect, Color.Gray, 1, ButtonBorderStyle.Solid, 
                                             Color.Gray, 0, ButtonBorderStyle.Solid, 
                                             Color.Gray, 1, ButtonBorderStyle.Solid, 
                                             Color.Gray, 0, ButtonBorderStyle.Solid);
        }
        //Reset spot when mouse leave
        private void dataGridView_MouseLeave(object sender, EventArgs e)
        {
            spot = Point.Empty;
        }
        //Update spot when mouse move 
        private void dataGridView_MouseMove(object sender, MouseEventArgs e)
        {
            spot = e.Location;
        }
