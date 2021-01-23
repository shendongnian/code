    private void buttonCancel_Click(object sender, EventArgs e)
    {
        foreach (Control ctrl in this.Controls)
        {
            formValidation.SetError(ctrl, string.Empty);
        }
        Close();
    }
