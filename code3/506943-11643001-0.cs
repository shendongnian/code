      private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.panel1.Height = pictureBox1.Top + e.Y; 
                this.panel1.Width = pictureBox1.Left + e.X;
            }
        }
