    private void viewscreen_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) 
            {
                MessageBox.Show(this, "Right Clicked on Panel");
            }            
        }
     private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(this, "Picture Clicked");
            //this.viewscreen_MouseClick(sender, e);
        }
