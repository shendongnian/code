    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tabControl1.SelectedTab == null)
            lblMessage.Text = "1";
        else
            lblMessage.Text = "";
    }
