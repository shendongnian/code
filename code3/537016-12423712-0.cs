    void gridView_Click(object sender, EventArgs e) {
        Point clickPoint = gridControl.PointToClient(Control.MousePosition);
        var hitInfo = gridView.CalcHitInfo(clickPoint);
        if(hitInfo.InRowCell) {
            int rowHandle = hitInfo.RowHandle;
            GridColumn column = hitInfo.Column;
        }
    }
