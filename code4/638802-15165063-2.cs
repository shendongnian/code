        StringBuilder SB = new StringBuilder();
    
        if (chkBend.Checked) SB.AppendLine("Bend/Stoop, ");
        if (chkDryDusty.Checked) SB.AppendLine("Dry/Dusty, ");
        // and so on
    
        SB.Append(TextBox1.Text);
        LblLimits.Text = SB.ToString();
