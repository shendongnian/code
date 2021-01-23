    private void btnSubmit_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("Webform2.aspx?Name=" +
        this.txtName.Text + "&LastName=" +
        this.txtLastName.Text);
    }
