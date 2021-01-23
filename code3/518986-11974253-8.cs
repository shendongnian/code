    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        e.Cell.Width = 150;
        e.Cell.Height = 100;
        DataSet ds = GetData();
    
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            DateTime scheduledDate = Convert.ToDateTime(row["lstdate"]);
            DateTime endDate = Convert.ToDateTime(row["lenddate"]);
    
            // make sure it meets your criteria
            if ((e.Day.Date >= scheduledDate && e.Day.Date <= endDate))
            {
                // create the hyperlink
                HyperLink hl = new HyperLink();
                hl.Text = "<br />" + row["lastname"].ToString() + "(" + row["stat1"].ToString() + ")";
                hl.NavigateUrl = "~/Form.aspx?requestid=" + row["bwrequestid"].ToString();
    
                // if the start and end dates are the same day, make it red
                if (scheduledDate.CompareTo(endDate) == 0)
                    hl.CssClass = "changecolor";
    
                // add control to cell
                e.Cell.Controls.Add(hl);
            }
        }
    }
