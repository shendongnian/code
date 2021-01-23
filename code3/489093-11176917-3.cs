    protected void duty_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);   
        DropDownList duty= (DropDownList) gvr.FindControl("duty");
        TextBox1.Text = duty.SelectedItem.Value;
    }
