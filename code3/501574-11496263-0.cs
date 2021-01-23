    protected DateTime UpdateDate(int offset)
    {
        DateTime dt;
        if (ViewState["LastDate"] == null)
           dt = DateTime.Now.AddMonths(offset);
        else
           dt = ((DateTime)ViewState["LastDate"]).AddMonths(offset);
        ViewState["LastDate"] = dt;
        return dt;
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        lblDateCal.Text = UpdateDate(-1).ToString("MMMM");
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        lblDateCal.Text = UpdateDate(1).ToString("MMMM");
    }
