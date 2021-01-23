    gridView.MouseDown += new MouseEventHandler(gridView_MouseDown);
    //...
    void gridView_MouseDown(object sender, MouseEventArgs e) {
        var hitInfo = gridView.CalcHitInfo(e.Location);
        if(hitInfo.InRowCell) {
            int rowHandle = hitInfo.RowHandle;
            GridColumn column = hitInfo.Column;
        }
    }
