    FormA _A = new FormA();
    public void HandleMainMenuClick(object sender, EventArgs e)
    {      
        if ((string)MainMenu.SelectedItem == "A")
        {    
            new_panel = _A.CreateMainPanel();
        }
        this.main_panel.Controls.Clear();
        this.main_panel.Controls.Add(new_panel);    
    }
