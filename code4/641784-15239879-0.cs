     DataTable dtEmp = new DataTable("EMP");
            dtEmp.Columns.Add("Name", typeof(String));
            dtEmp.Columns.Add("Address", typeof(String));
            dtEmp.Columns.Add("Contact", typeof(String));
            dtEmp.Columns.Add("Marks", typeof(String));
            DataTable dtStd = new DataTable("STD");
            dtStd.Columns.Add("StdName", typeof(String));
            dtStd.Columns.Add("StdAddress", typeof(String));
            
            foreach (DataColumn dc in dtStd.Columns)
            {
                dtEmp.Columns.Add(dc.ColumnName, dc.DataType);
            }
            // Import rows from dtStd Table.
