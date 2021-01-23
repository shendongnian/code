    DataTable myTable = new DataTable();
    myTable.Columns.Add("Id", typeof(int));
    myTable.Columns.Add("Name", typeof(string));
    
    DataRow myNewRow = null;
    for (int i = 0; i < 10; i++)
    {
    	myNewRow = myTable.NewRow();
    
    	myNewRow["Id"] = i;
    	myNewRow["Name"] = "Name " + i.ToString();
    
    	myTable.Rows.Add(myNewRow);
    }
    
    DataRow[] Array = myTable.Select("Id > 5");
    
    DataTable newTable = myTable.Clone();
    
    foreach (var item in Array)
    {
    	newTable.ImportRow(item);
    }
    
    listBox1.DataSource = newTable;
    listBox1.ValueMember = "Id";
    listBox1.DisplayMember = "Name";
