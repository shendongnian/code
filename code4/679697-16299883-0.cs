    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ViewState["dt"] != null)
        {
            DataTable dt = (DataTable)ViewState["dt"];
            if (dt.Rows.Count > 0)
            {
                string sqlFilter = "name = '" + DropDownList1.SelectedItem.Text + "'";
                DataRow[] data = dt.Select(sqlFilter);
                if (data.Length > 0)
                {
                    TextBox1.Text = data["Exp"].ToString();
                }
            }
        }
    }
