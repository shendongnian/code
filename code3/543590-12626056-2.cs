    private bool Dragging;
    private int xPos;
    private int yPos;
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e) { Dragging = false; }
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
        if (e.Button == MouseButtons.Left) { 
            Dragging = true;
            xPos = e.X;
            yPos = e.Y;
        }
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
        Control c = sender as Control;
        if (Dragging && c!= null) {
            c.Top = e.Y + c.Top - yPos;
            c.Left = e.X + c.Left - xPos;
        }
    }
