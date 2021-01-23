    string initText = "Love .NET";
    bool edited;
    //This code line is just for demonstrative purpose, it should be placed such as in the Form constructor
    textBox1.Text = initText;
    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        edited = !char.IsControl(e.KeyChar);
    }
    private void textBox1_Enter(object sender, EventArgs e)
    {
        if(!edited) textBox1.Clear();
    }
    private void textBox1_Leave(object sender, EventArgs e)
    {
        if (!edited) textBox1.Text = initText;
    }
