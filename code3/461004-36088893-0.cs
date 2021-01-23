    internal void UpdateLastImageDownloaded(string fullfilename)
    {
        this.BeginInvoke((MethodInvoker)delegate()
        {
            try
            {
                //pictureBoxImage.Image = Image.FromFile(fullfilename);
                //Bitmap bmp = new Bitmap(fullfilename);
                //pictureBoxImage.Image = bmp;
                System.IO.FileStream fs;
                // Specify a valid picture file path on your computer.
                fs = new System.IO.FileStream(fullfilename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                pictureBoxImage.Image = System.Drawing.Image.FromStream(fs);
                fs.Close();
            }
            catch (Exception exc)
            {
                Logging.Log.WriteException(exc);
            }
        });
    }
