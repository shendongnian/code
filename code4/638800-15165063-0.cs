        StringBuilder SB = new StringBuilder();
    
        if (chkBend.Checked) SB.Append("Bend/Stoop, ");
        if (chkDryDusty.Checked) SB.Append("Dry/Dusty, ");
        // and so on
    
        SB.Append(TextBox1.Text);
        LblLimits.Text = SB.ToString();
