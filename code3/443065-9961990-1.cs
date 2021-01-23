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
----------
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        wel.AddControl -= new EventHandler(SwapControls);
        pin.AddControl -= new EventHandler(SwapControls);
        pin.ReturnWelcome -= new EventHandler(SwapControls); 
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
