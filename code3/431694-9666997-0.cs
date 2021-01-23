    protected void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                    Boolean bitBlack = Convert.ToBoolean(e.Row.Cells[7]);
                    if (bitBlack)
                    {
                        e.Row.Cells[7].Text = "Yes";
                    }
                    else
                    {
                        e.Row.Cells[7].Text = "No";
                    }
                
            }
        }
