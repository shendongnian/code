    if (c.Picture != null)
    {
           byte[] newbit = c.Picture.ToArray();
            MemoryStream mem = new MemoryStream(newbit);
            picturePictureEdit.Image = new Bitmap(mem);
    
    }
    
    else
    {
    picturePictureEdit.Image = null;
    }
