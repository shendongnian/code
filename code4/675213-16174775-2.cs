    bool doCopy = true;
    foreach (RichTextBox rtb in scrlPanel.Children.OfType<RichTextBox>())
    {
        TextRange txtRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
        if (txtRange.Text.Trim() == string.Empty)
        {
            MessageBox.Show("Empty fields.");
            doCopy = false;
            break;
        }
      
    }
    if(doCopy)
    {
        foreach (RichTextBox rtb in scrlPanel.Children.OfType<RichTextBox>())
        {
            foreach (TextBlock txtb in texts)
            {
                //RichTextBox rtb = rtbs[texts.IndexOf(txtb)];
                //TextRange txtRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                raTemplate.Append(txtb.Text + " " + "::" + Environment.NewLine + txtRange.Text.Trim() + Environment.NewLine);
            }
        }
        Clipboard.SetText(raTemplate.ToString());
        RA_Email ra = new RA_Email();
        ra.raEmail();
    }
