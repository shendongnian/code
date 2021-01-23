    cs code:
    protected void TxtNumofDays_TextChanged1(object sender, EventArgs e)
    {
        MTMSDTO objc = new MTMSDTO();
        TxtNumofDays.Text = Session["NumofDays"].ToString();
        objc.NumofDays = Convert.ToInt32(TxtNumofDays.Text);
    }
    protected void TxtEndDate_TextChanged(object sender, EventArgs e)
    {
        DateTime BeginDate = Convert.ToDateTime(TxtBeginDate.Text);
        DateTime EndDate = Convert.ToDateTime(TxtEndDate.Text);
        TimeSpan diff = EndDate.Subtract(BeginDate);
        TxtNumofDays.Text = diff.Days.ToString();
        TxtNumofDays.Focus();
    }
