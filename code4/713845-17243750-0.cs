        SqlCommand cmdHeader = new SqlCommand("SELECT * FROM Header", conn);
        SqlCommand cmdReport = new SqlCommand("SELECT * FROM Report", conn);
        DataTable dtHeader = new DataTable();
        DataTable dtReport = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter(cmdHeader);
        da1.Fill(dtHeader)
        SqlDataAdapter da2 = new SqlDataAdapter(cmdReport);
        da2.Fill(dtReport);
        for(int x = dtReport.Columns.Count - 1; x >= 0; x--)
        {
            DataColumn dc = dtReport.Columns[x];
            if(!dtHeader.Columns.Contains(dc.ColumnName))
                 dtReport.Columns.Remove(dc.ColumnName);
        }
