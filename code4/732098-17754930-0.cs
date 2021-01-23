    private void button1_Click(object sender, EventArgs e)
    {
        ChangeColor(button1);
    }
    private void ChangeColor(Button button)
    {
        if (button.BackColor != Color.Lime)
            button.BackColor = Color.Lime;
        else
            button.BackColor = Color.White;
    }
