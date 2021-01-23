    private DataTable GetDataTable()
    {
       DataTable table = new DataTable("NameIsOptional");
       table.Columns.Add(new DataColumn("Emp_Id", typeof(int)));
       table.Columns.Add(new DataColumn("Emp_Code", typeof(string)));
       table.Columns.Add(new DataColumn("L_Name", typeof(string)));
       // set Column 'Emp_Code' as primary key column
       table.PrimaryKey = new DataColumn[] {table.Columns["Emp_Code"]};
       
       table.Rows.Add(1, "E001", "dave");
       table.Rows.Add(2, "E002", "mandle");
       table.Rows.Add(3, "E007", "sarana");
       table.Rows.Add(4, "E004", "poyekar");
       table.Rows.Add(5, "E005", "suryawanshi");
       table.Rows.Add(9, "E006", "survey");
       table.Rows.Add(11, "E003", "singh");
    
       return table;
    }
