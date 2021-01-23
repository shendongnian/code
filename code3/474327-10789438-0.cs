    protected void FormView2_DataBound(object sender, EventArgs e)
    {
    if (FormView2.CurrentMode == FormViewMode.Edit)
    {
        Label DAT_Label1 = (Label)FormView2.FindControl("DAT_Label1");
        if (DAT_Label1 != null)
        {
            DateTime date = Convert.ToDateTime(DAT_Label1.Text);
            DAT_Label1.Text = string.Format("{0:d}", date);
        }
    }
