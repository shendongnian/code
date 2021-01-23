    protected void CashPayButton_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in Cash_GridView.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox c = (CheckBox)row.FindControl("MemberCheck");
                if (c.Checked)
                {
                    //do calculation with other controls in the row
                }
            }
        }           
    }
