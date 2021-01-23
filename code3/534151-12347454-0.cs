    void ButtonA_Click(object sender, EventArgs e) 
    {
        // Action A
        BackButton.Tag = ButtonAClicked;
    }
    
    void ButtonB_Click(object sender, EventArgs e) 
    {
        // Action B
        BackButton.Tag = ButtonBClicked;
    }
    
    void BackButton_Click(object sender, EventArgs e)
    {
        if (((Button)sender).Tag !=null
            this.Invoke(ButtonB.Tag);
    }
