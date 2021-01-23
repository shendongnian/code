        DataTable r = new DataTable();
        try
        {
            r.Columns.Add("ID");
            r.Columns.Add("EmployerName");
            r.Columns.Add("FlatMinAmount");
            r.Columns.Add("DistrictRate");
            r.Columns.Add("VendorRate");
            r.Columns.Add("Description");
            r.Columns.Add("EmployeeCount");
            // Read sample data from CSV file
            using (CsvFileReader reader = new CsvFileReader(filename))
            {
                CsvRow row = new CsvRow();
                while (reader.ReadRow(row))
                {
                    //foreach (string s in row)
                    {
                        double d;
                        double? val2 = null;
                        double? val3 = null;
                        double? val4 = null;
                        if (Double.TryParse(row[2], out d)) val2 = d;
                        if (Double.TryParse(row[3], out d)) val3 = d;
                        if (Double.TryParse(row[4], out d)) val4 = d;
                        r.Rows.Add(row[0], row[1], val2, val3, val4, row[5], row[6]);
                    }
                }
            }
