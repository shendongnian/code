    protected void rptMonitorSummary_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        string[] tokens = e.CommandArgument.ToString().Split(',');
        int productId = int.Parse(tokens[0]);
        DateTime dateTime = Date.Time.Parse(tokens[1]);
        // the rest of the handling here
    }
