    //Creation of DataTable
    DataTable t = new DataTable("myTable");
    t.Columns.Add(new DataColumn("Field1", typeof(string)));
    t.Columns.Add(new DataColumn("Field2", typeof(int)));
    t.Columns.Add(new DataColumn("Field3", typeof(string)));
    t.Columns.Add(new DataColumn("Field4", typeof(string)));
    
    //Adding test data to DataTable
    t.Rows.Add(new object[] { "Value1", 300, "Test1", "Test2" });
    t.Rows.Add(new object[] { "Value2", 1100, "Test3", "Test4" });
    t.Rows.Add(new object[] { "Value3", 900, "Test5", "Test6" });
    t.Rows.Add(new object[] { "Value4", 100, "Test7", "Test8" });
    t.Rows.Add(new object[] { "Value5", 1200, "Test9", "Test10" });
    //Creation of DataSet
    DataSet s = new DataSet();
    s.Tables.Add(t);
    //Assigning DataSet to DataGridView (here's where you start looking)
    dataGridView1.DataSource = s;
    dataGridView1.DataMember = "myTable";
    foreach (DataGridViewRow r in dataGridView1.Rows)
    {
        foreach (DataGridViewCell c in r.Cells)
        {
            if (c != null && c.Value != null) //to avoid blank or 'new' rows
            {
                if (c.OwningColumn.Name == "Field2" && (int)c.Value > 1000)
                {
                    foreach (DataGridViewCell cell in c.OwningRow.Cells)
                    {
                        cell.Style.BackColor = Color.Aquamarine;
                    }
                }
            }
        }
    }
