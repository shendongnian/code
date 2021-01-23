    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Base;
    //...
    gridControl1.DataSource = new List<DataObj> {
        new DataObj(){ ID=0, Name="A" },
        new DataObj(){ ID=1, Name="B" },
        new DataObj(){ ID=2, Name="C" },
        new DataObj(){ ID=3, Name="D" },
    };
    gridView1.CustomDrawCell += gridView1_CustomDrawCell;
    //...
    void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e) {
        if(selectedRowHandle.GetValueOrDefault(GridControl.InvalidRowHandle) == e.RowHandle) {
            e.Appearance.BackColor = Color.Green;
        }
    }
    int? selectedRowHandle;
    void button1_Click(object sender, EventArgs e) {
        int prevSelectedRowHandle = selectedRowHandle.GetValueOrDefault(GridControl.InvalidRowHandle);
        if(prevSelectedRowHandle != GridControl.InvalidRowHandle)
            gridView1.RefreshRow(prevSelectedRowHandle); // reset row-style to default
        selectedRowHandle = gridView1.FocusedRowHandle;
        gridView1.InvalidateRow(gridView1.FocusedRowHandle); // row painting request
    }
