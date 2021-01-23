       foreach (DataColumn col in dt.Columns)
       {    
           BoundField field = new BoundField();
           field.DataField = col.ColumnName;
           field.HeaderText = col.ColumnName;
           GridView1.Columns.Add(field);
       }
       GridView1.AutoGenerateColumns = false;
       GridView1.DataSource = tbl; //a DataTable of your choice
       GridView1.DataBind();
