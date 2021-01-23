    // use for chkCarWheels, chkCarAcceleration, chkCarBreakpad
    private void chkCar_CheckedChanged(object sender, EventArgs e)
    {
        BuildMessage();
    }
    private void BuildMessage()
    {     
        lblMessage.Text = "My  " + txtName.Text + " Car";
        if (chkCarWheels.Checked)
            lblMessage.Text = lblMessage.Text + mycar.hasWheels(4);
        if (chkCarAcceleration.Checked)
           lblMessage.Text = lblMessage.Text + mycar.Accelerate();
        if (chkCarBreakpad.Checked)
           lblMessage.Text = lblMessage.Text + mycar.hasBreak();
    }
