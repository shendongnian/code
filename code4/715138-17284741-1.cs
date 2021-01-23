    var sb = new StringBuilder();
            sb.Append(@"{\rtf1\ansi");
            sb.Append(@"\b Name: \b0 ");
            sb.Append((txtFirstName.Text);
            sb.Append(@" \line ");
            sb.Append(@"\b DOB: \b0 ");
            sb.Append(txtDOBMonth.Text);
            sb.Append(@" \line ");
            sb.Append(@"\b ID Number: \b0 ");
            sb.Append(txtIdNumber.Text);
            sb.Append(@" \line \line ");
            sb.Append(@"}");
            
    richTextBox.Rtf = sb.ToString();
