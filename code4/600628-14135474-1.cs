    private void gridControl1_Click(object sender, EventArgs e) {
        GridControl grid = sender as GridControl;
        Point p = new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
        GridView gridView = grid.GetViewAt(p) as GridView;
        if(gridView != null)
            MessageBox.Show(gridView.GetFocusedRowCellDisplayText("Num"));
    }
