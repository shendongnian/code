        DataTable dt = new DataTable();
        dt.Columns.Add("EmpID");
        dt.Columns.Add("Field2");
        dt.Columns.Add("Field3");
        // Read file, split values, add to table
        while (!HeaderFile.EndOfStream) {
            headerRow  = HeaderFile.ReadLine();
            headerFields = headerRow.Split(',');
            // Create row and add it to the table
            DataRow dr = dt.NewRow();
            dr["EmpID"] = headerFields[0];
            dr["Field1"] = headerFields[1];
            dr["Field2"] = headerFields[2];
            dt.ImportRow(dr);
        }
        // Sort table by EmpID
        DataView dv = dt.DefaultView;
        dv.Sort = "EmpID ASC";
        dt = dv.ToTable();
