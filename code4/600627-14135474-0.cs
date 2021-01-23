        private void gridView1_MasterRowExpanded(object sender, CustomMasterRowEventArgs e) {
            GridView master = sender as GridView;
            GridView detail = master.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            detail.Click += new EventHandler(detail_Click);
        }
    
        void detail_Click(object sender, EventArgs e) {
                GridView gridView = sender as GridView;
    var value = gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns["Num"));
    MessageBox.Show(value.ToString());
        }
