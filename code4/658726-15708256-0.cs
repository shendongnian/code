    bool isMouseDown;
    private void labels_Click(object sender, EventArgs e)
    {
        DoAction(sender);
    }
      
    private void label1_MouseMove(object sender, MouseEventArgs e)
    {
        if (isMouseDown)
        {
            DoAction(sender);
        }
    }
    private void label3_MouseDown(object sender, MouseEventArgs e)
    {
        isMouseDown = true;
    }
    private void label3_MouseUp(object sender, MouseEventArgs e)
    {
        isMouseDown = false;
    }
    private void DoAction(object sender)
    {
        Label lbl = (Label)sender;
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
