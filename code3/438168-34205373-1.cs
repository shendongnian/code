    DataColumn title = new DataColumn();
    title.ColumnName = "Title";
    title.DataType = System.Type.GetType("System.String");
    title.Expression = "ItemName + ' - ' + ItemDescription";
    dataTable.Columns.Add(title);
    
    // Or in one line
    
    dataTable.Columns.Add(new DataColumn("Title", System.Type.GetType("System.String"), "ItemName + ' - ' + ItemDescription"));
    
    ddlItems.DataSource = dataTable;
    ddlItems.DataTextField = "Title";
    ddlItems.DataValueField = "Id";
    ddlItems.DataBind();
