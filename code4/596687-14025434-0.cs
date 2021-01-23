    private void btnAdd_Click(object sender, EventArgs e)
    {
        if(validURL(txtSubLink.Text))
        {
             HyperLink add = new HyperLink(txtSubLink.Text,txtSubText.Text,"URL");
             this.build = add;
             this.DialogResult = DialogResult.OK;
        }
        else
        {
            MessageBox.Show("Valid URL Needed! " + txtSubLink.Text, "ERROR");
        }
    }
