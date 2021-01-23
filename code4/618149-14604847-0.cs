    using DevExpress.XtraGrid.Views.Base;
    
    private void gridView1_CustomColumnDisplayText(object sender, 
    CustomColumnDisplayTextEventArgs e) {
       if(e.Column.FieldName == "Discount")
          if(Convert.ToDecimal(e.Value) == 0) e.DisplayText = "";
    }
