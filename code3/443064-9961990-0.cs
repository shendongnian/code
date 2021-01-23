    private void SwapControls(object sender, EventArgs e) 
    { 
        if (formPanel.Controls.Contains(wel)) 
        { 
            formPanel.Controls.Remove(wel); 
            formPanel.Controls.Add(pin); 
        } 
        else if (formPanel.Controls.Contains(pin) && Global.Instance.IsAuthenticated) 
        { 
            formPanel.Controls.Remove(pin); 
            formPanel.Controls.Add(mmenu); 
        } 
        else 
        { 
            formPanel.Controls.Remove(pin); 
            formPanel.Controls.Add(wel); 
        } 
    } 
