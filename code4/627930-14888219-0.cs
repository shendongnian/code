    // Provides data for the Total column.
    void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
       if (e.Column.FieldName == "Total" && e.IsGetData) e.Value = 
         getTotalValue(e.ListSourceRowIndex);
    }
    // Returns the total amount for a specific row.
    decimal getTotalValue(int listSourceRowIndex) {
        DataRow row = nwindDataSet.Tables["Order Details"].Rows[listSourceRowIndex];
        decimal unitPrice = Convert.ToDecimal(row["UnitPrice"]);
        decimal quantity = Convert.ToDecimal(row["Quantity"]);
        decimal discount = Convert.ToDecimal(row["Discount"]);
        return unitPrice * quantity * (1 - discount);
    }
