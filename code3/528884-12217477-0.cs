    private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) {
    
        GridView view = sender as GridView;
        if(e.Column.VisibleIndex == 0 && view.IsMasterRowEmpty(e.RowHandle))
            (e.Cell as GridCellInfo).CellButtonRect = Rectangle.Empty;
        }
    }
