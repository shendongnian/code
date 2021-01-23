    private void Handle_New_Frame(object sender, NewFrameEventArgs eventArgs)
    {
        var newBitmap = new Bitmap(eventArgs.Frame);
        //This assumes the picture box descends from Control
        if(videoPictureBox1.InvokeRequired)        
        {
            Action action = () => videoPictureBox1.Image = newBitmap;
            //Invoke to make the action happen on the GUI thread
            videoPictureBox1.Invoke(action);
        }
        else
            videoPictureBox1.Image = newBitmap;    
        //Dispose the old bitmap now that it is not assigned to the picturebox anymore   
        if (bitmap != null)
            bitmap.Dispose();
        bitmap = newBitmap;
    }
