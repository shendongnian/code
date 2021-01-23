    private void Handle_New_Frame(object sender, NewFrameEventArgs eventArgs)
    {
        if(bitmap != null)
            bitmap.Dispose();
        bitmap = new Bitmap(eventArgs.Frame);
    
        if(videoPictureBox1.Image != null)
            videoPictureBox1.Image.Dispose();
        videoPictureBox1.Image = bitmap;
    }
