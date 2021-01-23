    private void richTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
    {
        // Replace any unicode non-break space characters with ' ' characters:
        string linkText = e.LinkText.Replace((char)160, ' ');
      
        // For some reason rich text boxes strip off the 
        // trailing ')' character for URL's which end in a 
        // ')' character, so if we had a '(' opening bracket
        // but no ')' closing bracket, we'll assume there was
        // meant to be one at the end and add it back on. This 
        // problem is commonly encountered with wikipedia links!
       
        if((linkText.IndexOf('(') > -1) && (linkText.IndexOf(')') == -1))
            linkText += ")";
        System.Diagnostics.Process.Start(linkText);
    }
