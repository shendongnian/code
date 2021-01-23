    private void chkDisable_CheckedChanged(object sender, EventArgs e)
    {
            if (((CheckBox)sender).Checked)
            {
                DisableFormFields();
            }
            else
            {
                EnableFormFields();
            }
    }
