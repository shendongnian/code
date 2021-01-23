    public PictureBox AddPictureBox()
    {
        try
        {
            PictureBox _picBox = new PictureBox();
            ......
            return _picBox;
        }
        catch (Exception e)
        {
            Trace.WriteLine(e.Message);
            return null;
        }
    }
    private void MouseDown( object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            PictureBox pic = _testImage.AddPictureBox();
            if(pic != null)
            {
                this.Controls.Add(pic);
                Trace.WriteLine("Picture box added");
        }
    } 
