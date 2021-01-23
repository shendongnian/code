            protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (Session["Month"] != null)
                {
                    if (DropDownList2.SelectedValue == Session["Month"])
                    {
                        DropDownList2.SelectedValue = string.Empty;
                    }
                }
            }
