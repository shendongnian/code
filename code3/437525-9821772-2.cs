    private void ColorButtons_Click(object sender, EventArgs e)
    {
        Control item = (Control)sender;
        if(item.tag == "greenColor")
            this.BackColor = Color.Green;
        else if(item.tag == "blueColor")
            this.BackColor = Color.Blue;
        // and so on
    }
