    gridView1.RowStyle += gridView1_RowStyle;
    
    
    private void gridView1_RowStyle(object sender, 
    DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e) {
       GridView view = sender as GridView;
       if(e.RowHandle >= 0) {
          bool isRed = Convert.ToBoolean(view.GetRowCellDisplayText(e.RowHandle, view.Columns["Category"]));
          if(isRed) {
             e.Appearance.BackColor = Color.Red;
          }            
       }
    }
