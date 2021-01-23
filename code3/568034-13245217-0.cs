    int x_offset = 0; // any better to do this without having a global variable?
    int y_offset = 0;
    private void pic_MouseDown(object sender, MouseEventArgs e)
    {
       PictureBox me = (PictureBox)sender;
       x_offset = e.X;
       y_offset = e.Y;
    }
    
    private void pic_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button == System.Windows.Forms.MouseButtons.Left)
      {
         PictureBox me = (PictureBox)sender;
         me.Left = e.X + me.Left - x_offset;
         me.Top = e.Y + me.Top - y_offset;
       }
    }
