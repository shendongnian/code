    private DataSet GetData()
    {
        // create a test data set
        DataTable dt = new DataTable();
        dt.Columns.Add("stat1");
        dt.Columns.Add("lastname");
        dt.Columns.Add("firstname");
        dt.Columns.Add("lstdate");
        dt.Columns.Add("lenddate");
        dt.Columns.Add("bwrequestid", typeof(Int64));
    
        dt.Rows.Add("P", "Doe", "John", "08/16/2012", "08/16/2012", 1);
        dt.Rows.Add("P", "Doe", "Jane", "08/14/2012", "08/17/2012", 2);
        dt.Rows.Add("C", "Black", "Jack", "08/12/2012", "08/12/2012", 3);
        dt.Rows.Add("C", "Morgan", "Dexter", "08/01/2012", "08/07/2012", 4);
        dt.Rows.Add("S", "Swearengen", "Al", "08/15/2012", "08/20/2012", 5);
        dt.Rows.Add("S", "Kirk", "James", "08/04/2012", "08/04/2012", 6);
        dt.Rows.Add("P", "Bundy", "Al", "08/07/2012", "08/07/2012", 7);
    
        DataSet ds = new DataSet();
        ds.Tables.Add(dt);
    
        return ds;
    
    }
    
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
                    hl.CssClass = "disabledbtn";
    
                // add control to cell
                e.Cell.Controls.Add(hl);
            }
        }
    }
