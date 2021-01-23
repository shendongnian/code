    protected void rdoDateRange_CheckedChanged(object sender, EventArgs e)
            {
                DateTime startdate = DateTime.Now.AddHours(2);
                DateTime enddate = DateTime.Now.AddHours(5);
                TimeSpan  result = enddate - startdate;
                txtDays.Text = result.ToString();
                Update1.Update();
            }
     protected void rdoSpecifiedDates_CheckedChanged(object sender, EventArgs e)
            {
    
            }
