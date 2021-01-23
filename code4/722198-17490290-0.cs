    private int xPos;
    private int yPos;
 
    private void pb_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
           xPos = e.X;
           yPos = e.Y;
        }
    }
    private void pb_MouseMove(object sender, MouseEventArgs e)
    {
        PictureBox p = sender as PictureBox;
        if(p != null)
        {
            if (e.Button == MouseButtons.Left)
            {
                p.Top += (e.Y - yPos);
                p.Left +=  (e.X - xPos);
            }
        }
    }
