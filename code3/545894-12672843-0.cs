    protected void CheckChanged(object sender, EventArgs e)
    {
            chk = (CheckBox)sender
            if (!chk.Checked)
            {
                checkcount--;
                lblCheck.Text = checkcount.ToString();
            }
            else
            {
                checkcount++;
                lblCheck.Text = checkcount.ToString();
            }
    }
