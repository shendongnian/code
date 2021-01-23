    private void preview()
    {
        Bitmap bmp1 = new Bitmap(2480, 3508);
        panel1.DrawToBitmap(bmp1, new Rectangle(0, 0, 2480, 3508));
        Image img = pictureBox2.Image;
        pictureBox2.Image = bmp1;
        if (img != null) img.Dispose(); // the first time it'll be null
    }
    private void btnUpdate_Click(object sender, EventArgs e)
    {
        preview();
        System.GC.Collect();
        System.GC.WaitForPendingFinalizers();
    }
