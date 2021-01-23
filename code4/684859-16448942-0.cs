    List<TextBox> _disable = new List<TextBox>(); 
    List<TextBox _enable = new List<TextBox>(); 
    
    // Gather Textboxes to be disabled and enabled 
    foreach(Control c in this.Controls)
    {
        GroupBox group = c as GroupBox; 
        if(group == null ) // Not a group box so continue on 
            continue; 
        foreach(Control c in group.Controls)
        {
            TextBox tb = c as TextBox; 
            if(tb == null )
               continue; // Not a textbox so continue on 
            
            if(!String.IsNullOrWhitespace(tb.Text)) // We have information so add to _enable
               _enable.Add(tb); 
            else 
               _disable.Add(tb); // empty textbox so ... disable 
        }
    }
    // Enable or Disable Textboxes 
    foreach(TextBox tb in _enable)
    {
       tb.Enabled = true; 
       tb.BackColor = Colors.White
    }
    foreach(TextBox tb in _disable)
    {
       tb.Enabled = false; 
       tb.BackColor = Colors.LightGrey 
    }
