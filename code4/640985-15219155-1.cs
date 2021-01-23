     private void Form_Load(object sender, EventArgs e) {
        this.tableLayoutPanel1.CellPaint += new TableLayoutCellPaintEventHandler(tableLayoutPanel1_CellPaint);
     }
    void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
    {
        if (e.Row == 0 || e.Row == 2) {
            Graphics g = e.Graphics;
            Rectangle r = e.CellBounds;
            g.FillRectangle(Brushes.Blue, r);
        }
    }
