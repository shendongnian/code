    private void grvAssesse_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
    {
      if (e.RowHandle >= 0)
      {
        GridView View = sender as GridView;        
        if (Condition)
        {
          e.Appearance.ForeColor = Color.Red;
        }
      }
    }
