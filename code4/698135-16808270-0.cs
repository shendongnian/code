    DataTable dttable = new DataTable();
    DataColumn column;
    DataRow row; 
    
    column = new DataColumn();
    column.DataType = Type.GetType("System.String");
    column.ColumnName = "EmpName";
    dttable.Columns.Add(column);
 
    row = table.NewRow();   
    row["EmpName"] = DropDownList1.SelectedText;
    dttable.Rows.Add(row);
    Gridview1.DataSource = dttable;
    Gridview1.DataBind();
