    protected void ddlFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListItem item in ddlSecond.Items)
            {
                if (item.ToString() == ddlFirst.SelectedValue)
                {
                    item.Attributes.Add("disabled", "disabled");
                }
            }
        }
        protected void ddlSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListItem item in ddlFirst.Items)
            {
                if (item.ToString() == ddlSecond.SelectedValue)
                {
                    item.Attributes.Add("disabled", "disabled");
                }
            }
        }
