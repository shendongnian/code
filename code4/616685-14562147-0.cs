    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Columns;
    
    private void Form1_Load(object sender, System.EventArgs e) {
       // ...
       gridControl1.ForceInitialize();
    
       // Create an unbound column.
       GridColumn unbColumn = gridView1.Columns.AddField("Total");
       unbColumn.VisibleIndex = gridView1.Columns.Count;
       unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
       // Disable editing.
       unbColumn.OptionsColumn.AllowEdit = false;
       // Specify format settings.
       unbColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
       unbColumn.DisplayFormat.FormatString = "c";
       // Customize the appearance settings.
       unbColumn.AppearanceCell.BackColor = Color.LemonChiffon;
    }
    
    // Returns the total amount for a specific row.
    decimal getTotalValue(int listSourceRowIndex) {
        DataRow row = nwindDataSet.Tables["Order Details"].Rows[listSourceRowIndex];
        decimal unitPrice = Convert.ToDecimal(row["UnitPrice"]);
        decimal quantity = Convert.ToDecimal(row["Quantity"]);
        decimal discount = Convert.ToDecimal(row["Discount"]);
        return unitPrice * quantity * (1 - discount);
    }
    
    // Provides data for the Total column.
    private void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
       if (e.Column.FieldName == "Total" && e.IsGetData) e.Value = 
         getTotalValue(e.ListSourceRowIndex);
    }
