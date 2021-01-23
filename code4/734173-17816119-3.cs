        // Find distinct projects
        var distinctProjects = (from r in dt.AsEnumerable()
            select r["ProjectName"]).Distinct().OrderBy(project => project);
        // Get all amounts to tally later for the All Total entry
        var allEntries = from r in dt.AsEnumerable()
            select r["SourceAmount"];
        // Loop through distinct project list and add project subtotal row to table
        foreach (var p in distinctProjects)
        {
            var amt = from r in dt.AsEnumerable()
                where r["ProjectName"] == p
                select r["SourceAmount"];
            DataRow dr = dt.NewRow();
            dr["ProjectName"] = p + " Total:";
            dr["SourceAmount"] = amt.Sum(x => Convert.ToDecimal(x));
            dt.Rows.Add(dr);
        }
        // Sort table so the sub totals fall under the project it belongs to
        DataView dv = dt.DefaultView;
        dv.Sort = "ProjectName ASC, Source ASC";
        dt = dv.ToTable();
        // Create and add the final total row
        DataRow finalTotal = dt.NewRow();
        finalTotal["ProjectName"] = "All Total:";
        finalTotal["SourceAmount"] = allEntries.Sum(x => Convert.ToDecimal(x));
        dt.Rows.Add(finalTotal);
        // Display correct results with message box
        foreach (DataRow r in dt.Rows) {
            MessageBox.Show(
                r["ProjectName"].ToString() + "    " +
                r["Source"].ToString() + "    " +
                r["SourceAmount"].ToString()
            );
        }
