    private void BuildMessage()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("My {0} Car", txtName.Text);
        if (chkCarWheels.Checked)
            sb.Append(mycar.hasWheels(4));
        if (chkCarAcceleration.Checked)
           sb.Append(mycar.Accelerate());
        if (chkCarBreakpad.Checked)
           sb.Append((mycar.hasBreak());
        lblMessage.Text = sb.ToString();
    } 
        
