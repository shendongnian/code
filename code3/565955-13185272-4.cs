    protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.DataItem != null)
                {
                    string grade = DataBinder.Eval(e.Row.DataItem, "Grade") as string;
                    if (!string.IsNullOrEmpty(grade))
                    {
                        RadioButtonList radio = e.Row.FindControl("rblChoices") as RadioButtonList;
                        radio.Items.FindByValue(grade).Selected = true;
                        //You can use this to select as well - see comments from Andomar
                        //radio.SelectedValue = grade;
                    }
                }
            }
        }
