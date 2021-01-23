    using DevExpress.XtraGrid.Views.Base;
    
    ColumnView View = gridControl1.MainView as ColumnView;
    DialogResult answer = MessageBox.Show("Do you want to create columns for all fields?", 
      "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    if (answer == DialogResult.Yes)
       View.PopulateColumns();
    else {
       string[] fieldNames = new string[] {"ProductID", "ProductName", "QuantityPerUnit", "UnitPrice"};
       DevExpress.XtraGrid.Columns.GridColumn column;
       View.Columns.Clear();
       for (int i = 0; i < fieldNames.Length; i++) {
          column = View.Columns.AddField(fieldNames[i]);
          column.VisibleIndex = i;
       }
    }
