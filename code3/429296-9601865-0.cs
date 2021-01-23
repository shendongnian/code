            // Unquoted filter string bizzareness.
            var table = new DataTable();
            table.Columns.Add(new DataColumn("NumbersAsString", typeof(String)));
            var row1 = table.NewRow(); row1["NumbersAsString"] = "9"; table.Rows.Add(row1); // Change to '66
            var row2 = table.NewRow(); row2["NumbersAsString"] = "74"; table.Rows.Add(row2);
            var row4 = table.NewRow(); row4["NumbersAsString"] = "90"; table.Rows.Add(row4);
            var row3 = table.NewRow(); row3["NumbersAsString"] = "710"; table.Rows.Add(row3);
            var results = table.Select("NumbersAsString = 710"); // Returns 0 rows.
            var results2 = table.Select("NumbersAsString = 74"); // Throws exception "Min (1) must be less than or equal to max (-1) in a Range object." at System.Data.Select.GetBinaryFilteredRecords()
