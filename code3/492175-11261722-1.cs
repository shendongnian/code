    public void UserControl_KeyDown(object sender, KeyEventArgs e) 
    { 
        if (e.Control)
        {
            switch (e.KeyCode) 
            { 
                case Keys.F: 
                    this.cmbxProtocol.Focus(); 
                    break; 
                // Other cases ...
                default: 
                    break; 
            }
        }
    } 
