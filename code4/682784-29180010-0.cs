     private void pictureBox7_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    xPos = e.X;
                    yPos = e.Y;
                }
            }
    
            private void pictureBox7_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                PictureBox p = sender as PictureBox;
    
                if (p != null)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        p.Top += (e.Y - yPos);
                        p.Left += (e.X - xPos);
                    }
                }
               
            }
