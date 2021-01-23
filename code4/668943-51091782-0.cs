    private void PictureBox_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            var pb = (PictureBox)sender;
            if (pb.BackgroundImage != null)
            {
                pb.DoDragDrop(pb, DragDropEffects.Move);
            }
        }
    }
    private void PictureBox_DragEnter (object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Move;
    }
    private void PictureBox_DragDrop (object sender, DragEventArgs e)
    {
        var target = (PictureBox)sender;
        if (e.Data.GetDataPresent(typeof(PictureBox)))
        {
            var source = (PictureBox)e.Data.GetData(typeof(PictureBox));
            if (source != target)
            {
                // You can swap the images out, replace the target image, etc.
                SwapImages(source, target);
            }
        }
    }
