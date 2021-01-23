    protected void dropEnquiryType_Changed(Object sender, EventArgs e)
    {
        lblComments.Visible = dropEnquiryType.SelectedValue == "Other";
        textComments.Visible = lblComments.Visible;
    }
