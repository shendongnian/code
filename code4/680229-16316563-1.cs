    protected void Page_Load(object sender, EventArgs e)
    {
        UserControl US = FindControl("CompanyLhsMenu") as UserControl;
        Literal ltrel;
        try
        {
            US = (UserControl)Master.FindControl("menu");
            ltrel = (Literal)US.FindControl("SavedCVLiteral");
            if (ltrel != null)
            {
                ltrel.Text = "update it";
            }
        }
        catch (Exception ex)
        {
        }
    }
