    private void ChartControlDragOver(object sender, DragEventArgs e) {
    var chartControl = (ChartControl)sender;
    // get the control we are hovering over.
    var hitInformation = chartControl.CalcHitInfo(chartControl.PointToClient(new Point(e.X, e.Y)));
    if ((hitInformation != null)) {
        //ChartHitInfo hoverTab = hitInformation;
        if (e.Data.GetDataPresent(typeof(ChartControl))) {
            e.Effect = DragDropEffects.Move;
            var dragTab = (ChartControl)e.Data.GetData(typeof(ChartControl));
            if (dragTab == chartControl) return;
            InsertType insertType = InsertType.Left;
            Point hitPoint = chartControl.Parent.PointToClient(new Point(e.X, e.Y));
            if (dragTab.Bounds.Left < hitPoint.X && dragTab.Bounds.Right > hitPoint.X) {
                if (dragTab.Bounds.Top > hitPoint.Y)
                    insertType = InsertType.Top;
                else if (dragTab.Bounds.Bottom < hitPoint.Y)
                    insertType = InsertType.Bottom;
            } else if (dragTab.Bounds.Right < hitPoint.X)
                insertType = InsertType.Right;
            else if (dragTab.Bounds.Left > hitPoint.X)
                insertType = InsertType.Left;
            LayoutControl layout = (LayoutControl)chartControl.Parent;
            layout.GetItemByControl(dragTab).Move(layout.GetItemByControl(chartControl), insertType);
        }
    } else {
        e.Effect = DragDropEffects.None;
    }
}
