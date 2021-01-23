    private void Handle_New_Frame(object sender, NewFrameEventArgs eventArgs)
    {
      this.Invoke((MethodInvoker)delegate
      {
        try
        {
            if (bitmap != null)
            {
                bitmap.Dispose(); //Without this, memory goes nuts
            }
            bitmap = new Bitmap(eventArgs.Frame);
        }
        catch { }
        //Draw some stuff on the images
        bitmap = AdjustBrightness(bitmap, brightnessMeter);
        bitmap = ApplyContrast(contrastMeter, bitmap);
        bitmap = Draw_Top_Line(bitmap);
        bitmap = Draw_Bottom_Line(bitmap);
        //Set the image into the picturebox
        this.Invoke((MethodInvoker)delegate
        {
            videoPictureBox1.Image = bitmap;
            frameRate++; //Keep track of the frame rate
        });
        GC.Collect(); //Without this, memory goes nuts
      });
    }
