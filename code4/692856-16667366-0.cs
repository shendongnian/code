    private void pictureBox1_Click(object sender, EventArgs e)
    {
        Access ac = new Access();
        ac.PictureClicked(sender);
    }
     public void PictureClicked(Object Sender)
    {
               picBox = (PictureBox)Sender;
               picBox.Image = Properties.Resources.apple;
     }
