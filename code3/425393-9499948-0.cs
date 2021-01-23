    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    Label label = e.Row.FindControl("RowLabel") as Label;
                   label.Text = "the text i want";
                }
            }
