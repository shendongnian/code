    DataTable table = new DataTable();
    table.Columns.Add("name", typeof(string));
    table.Columns.Add("value", typeof(string));
    
    string name = "A,B,C,D";
    string value = "100,200,300,400";
    
    string[] names = name.Split(',');
    string[] values = value.Split(',');
    
    for(int i=0; i<names.Length; i++)
        table.Rows.Add(new object[]{ names[i], values[i] });
