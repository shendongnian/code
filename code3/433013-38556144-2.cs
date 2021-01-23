    private void Form3_FormClosed(object sender, FormClosedEventArgs e)
    {
        var bmp = pictureBox1.Image as IDisposable;
        if (bmp!= null )
        {
            bmp.Dispose();
        }
    }
