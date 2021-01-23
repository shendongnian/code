    private void myBtn_GotFocus(object sender, EventArgs e)
    {
        myBtn.BackColor = Color.Silver;
    }
    private void myBtn_LostFocus(object sender, EventArgs e)
    {
        myBtn.BackColor = SystemColors.Control;
    }
