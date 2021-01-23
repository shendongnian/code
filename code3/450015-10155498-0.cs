    gcProxies.DataSource = dt;
    // Create an unbound column.
    DevExpress.XtraGrid.Columns.GridColumn unbColumn = gridView1.Columns.AddField("Total");
    unbColumn.VisibleIndex = gridView1.Columns.Count;
    unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
    // Disable editing.
    unbColumn.OptionsColumn.AllowEdit = false;
    // Specify format settings.
    unbColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
    unbColumn.DisplayFormat.FormatString = "c";
    gridView1.CustomUnboundColumnData += gridView1_CustomUnboundColumnData;
