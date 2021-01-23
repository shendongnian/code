    private void txtName_TextChanged(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(((Control)sender).Text))
        {
            tt.SetToolTip((Control)sender, "");
        }
    }
