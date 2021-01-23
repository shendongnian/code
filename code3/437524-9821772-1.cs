    private void ColorButtons_Click(object sender, EventArgs e)
    {
        Control item = (Control)sender;
        if(item.Name.Contains("greenButton"))
            this.BackColor = Color.Green;
        else if(item.Name.Contains("blueButton"))
            this.BackColor = Color.Blue;
        // and so on
    }
