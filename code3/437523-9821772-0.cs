    private void ColorButtons_Click(object sender, EventArgs e)
    {
        ToolStripMenuItem item = (ToolStripMenuItem)sender;
        if(item.Name == "greenButton")
            this.BackColor = Color.Green;
        else if(item.Name == "blueButton")
            this.BackColor = Color.Blue;
        // and so on
    }
