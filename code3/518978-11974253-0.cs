    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        // always set width and height.
        // way better off just setting a CSS Class in the Calendar object
        e.Cell.Width = 120;
        e.Cell.Height = 100;
    
        // skip fields that don't meet your criteria
        if ((start > 0) || (end < 0) || (e.Day.IsWeekend == true))
            return;
    
        // add hyper link
        HyperLink hl = new HyperLink();
        hl.Text = "yes";
        // determine color
        if (scheduledDate.CompareTo(endDate) == 0)
        {
            hl.ForeColor = System.Drawing.Color.Red;
        }
    
        e.Cell.Controls.Add(hl);
    }
