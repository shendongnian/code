        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["Month"] != null)
            {
                if (DropDownList1.SelectedValue == Session["Month"])
                {
                    DropDownList1.SelectedValue = string.Empty;
                }
                else
                {
                    Session["Month"] = DropDownList1.SelectedValue;
                }
            }
        }
