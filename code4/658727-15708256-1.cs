    bool isMouseDown;
    private void labels_Click(object sender, EventArgs e)
    {
        DoAction(sender);
    }
    private void labels_MouseDown(object sender, MouseEventArgs e)
    {
        isMouseDown = true;
        DoAction(sender);
    }
    private void labels_MouseUp(object sender, MouseEventArgs e)
    {
        isMouseDown = false;
    }
    private void label_MouseEnter(object sender, EventArgs e)
    {
        if (isMouseDown)
        {
            DoAction(sender);
        }
    }
    
    private void DoAction(object sender)
    {
        Label lbl = (Label)sender;
        lbl.Capture = false;           //DO NOT FORGET THIS LINE
        if (lbl.Text == "1")
        {
            lbl.Text = "0";
            lbl.BackColor = Color.FromArgb(225, 0, 0);
        }
        else
        {
            lbl.Text = "1";
            lbl.BackColor = Color.FromArgb(224, 224, 226);
        }
        SetHexNumbers();
    }
