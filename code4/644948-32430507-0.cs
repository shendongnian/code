    void pictureBox_MouseDown(object sender, MouseEventArgs e)
    {
    if (e.Button == MouseButtons.Left && e.Clicks ==1)
    {
    PictureBox pb = (PictureBox)sender;
    DoDragDrop((ImageData)pb.Tag, DragDropEffects.Copy);
    }
    }
