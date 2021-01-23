    DataTable oTable = new DataTable();
    oTable.Columns.Add("ID", typeof(int));
    oTable.Columns.Add("TITLE", typeof(string));
    
    DataRow oNewRow = null;
    for (int i = 0; i < 10; i++) 
    {
        oNewRow = oTable.NewRow();
    
        oNewRow["ID"] = i;
        oNewRow["TITLE"] = "Title_" + i.ToString();
    
        oTable.Rows.Add(oNewRow);
    }
    
    listBox1.DataSource = oTable;
    listBox1.ValueMember = "ID";
    listBox1.DisplayMember = "TITLE";
