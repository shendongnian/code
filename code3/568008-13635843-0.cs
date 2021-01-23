        protected void tableResults_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = e.Row.DataItem as DataRowView;
                if (row != null)
                {
                    Label lbImagePath = e.Row.FindControl("lbImagePath") as Label;
                    lbImagePath.Text = row["ImagePathColumn"].ToString();
                }
            }
        }
