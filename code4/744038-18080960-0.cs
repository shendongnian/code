    gridView1.RowStyle += gridView1_RowStyle;
    
    
    private void gridView1_RowStyle(object sender, 
    DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e) {
       GridView view = sender as GridView;
       if(e.RowHandle >= 0) {
          string category = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Category"]);
          if(category == "Beverages") {
             e.Appearance.BackColor = Color.Salmon;
             e.Appearance.BackColor2 = Color.SeaShell;
          }            
       }
    }
