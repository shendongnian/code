    private void pic_Image_MouseEnter(object sender, MouseEventArgs e)
    {
        btn_AddImage.Visible = true;
        btn_RemoveImage.Visible = true;
        if (pic_Image.Image != null)
            btn_RemoveImage.Visible = true;
    }
