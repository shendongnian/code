    PictureBox o = new PictureBox();
    o.MouseHover += (a_sender, a_args) =>
    {
        PictureBox pic = a_sender as PicureBox;
        pic.Image = null // New Image..
    };
