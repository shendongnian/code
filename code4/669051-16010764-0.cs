    Point selectedCell = new Point();
    private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            
           //show contextMenuStrip
            selectedCell = new Point(e.X / (tableLayoutPanel1.Width / tableLayoutPanel1.ColumnCount), e.Y / (tableLayoutPanel1.Height / tableLayoutPanel1.RowCount));
        }
    }
