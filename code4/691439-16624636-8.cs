    private void pictureBox1_MouseClick(object sender, mouseEventArgs e)
    {
        int minute = minuteAtPictureBoxCoord(e.X);
        MessageBox.Show(minute.ToString());
    }
