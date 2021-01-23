    protected void Button1_Click(object sender, EventArgs e)
    {
        UserControl_Type uc1 = 
        (UserControl_Type)ContentPlaceHolder1.FindControl("UserControlId");
        if (uc1 != null)
        {
            uc1.Method();
        }
    }
