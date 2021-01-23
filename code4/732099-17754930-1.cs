    private void button_Click(object sender, EventArgs e)
    {
        var button = (Button)sender;
        if (button.BackColor != Color.Lime)
            button.BackColor = Color.Lime;
        else
            button.BackColor = Color.White;
    }
