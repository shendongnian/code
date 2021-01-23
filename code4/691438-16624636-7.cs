    private void pictureBox1_Click(object sender, EventArgs e)
    {
        var mouseEventArgs = e as MouseEventArgs;
        if (mouseEventArgs != null)
        {
            int minute = minuteAtPictureBoxCoord(mouseEventArgs.X);
            MessageBox.Show(minute.ToString());
        }
    }
