        public TableForm() {
            InitializeComponent();
            this.tableLayoutPanel.CellPaint += tableLayoutPanel_CellPaint;
        }
        private void tableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e) {
            e.Graphics.DrawLine(Pens.Black, e.CellBounds.Location, new Point(e.CellBounds.Right, e.CellBounds.Top));
        }
