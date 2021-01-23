    void Form1_Load(object sender, EventArgs e) {
        DataTable dt = new DataTable();
        dt.Columns.Add("Test", typeof(string));
        dt.Rows.Add("A");
        dt.Rows.Add("A");
        dt.Rows.Add("A");
        dt.Rows.Add("A");
        dt.Rows.Add("A");
        dt.Rows.Add("A");
        gridControl1.DataSource = dt;
    
        ContextMenuStrip ctsForm = new ContextMenuStrip();
        ctsForm.Items.Add("Form");
        ctsForm.Opening += ctsForm_Opening;
        this.ContextMenuStrip = ctsForm;
    
        ContextMenuStrip ctsGrid = new ContextMenuStrip();
        ctsGrid.Items.Add("Grid Row!");
        ctsGrid.Opening += ctsGrid_Opening;
        gridControl1.ContextMenuStrip = ctsGrid;
        // gridView1.PopupMenuShowing removed at all
    }
    void ctsGrid_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
        e.Cancel = !IsPointInGridRow(gridView1, gridControl1.PointToClient(Control.MousePosition));
    }
    void ctsForm_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
       // some code
    }
    static bool IsPointInGridRow(GridView view, Point pt) {
        return view.CalcHitInfo(pt).InRow;
    }
