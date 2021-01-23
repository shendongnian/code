    private void btn1_Click(object sender, EventArgs e)
    {
        btn1.Width = 120;
        btn1.Height = 100;
    }
    void btn1_Resize(object sender, EventArgs e)
    {
        if ( this.BackgroundImage == null )
    	      return;
        var bm = new Bitmap(btn1.BackgroundImage, new Size(btn1.Width, btn1.Height));
        btn1.BackgroundImage = bm;
    }
