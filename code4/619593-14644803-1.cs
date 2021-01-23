    public void AddPictureBox(Form f)
    {
        try
        {
            PictureBox _picBox = new PictureBox();
            ......
            f.Controls.Add(_picBox);
        }
        catch (Exception e)
        {
            Trace.WriteLine(e.Message);
        }
    }
