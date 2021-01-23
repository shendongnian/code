    void myGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
            TextBox txtVal = (TextBox)e.Row.FindControl("txtVal");
            DropDownList drpVal = (DropDownList)e.Row.FindControl("drpVal");
            if (txtVal != null && drpVal != null)
            {
                if (condition == true)
                {
                    txtVal.Text = "Default value";
                    drpVal.Visible = false;
                }
                else
                {
                    drpVal.Items.Add("Item1");
                    drpVal.Items.Add("Item2");
                    drpVal.Items.Add("Item3");
                    txtVal.Visible = false;
                }
            }
    }
