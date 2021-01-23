    else if(pbspic == null) /* Or it could be pbspic.Image == null, depends on which is null */ 
    {
       ep.SetError(tbmonfee, "Image is missing.");
       return;
    }
    else
    {
    using (MemoryStream stream = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(pbspic.Image);
                    bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    stream.Position = 0;
                    byte[] data = new byte[stream.Length];
                    stream.Read(data, 0, data.Length);
                }
    if(data == null) /* Or check data length if it's never null */ 
    {
       ep.SetError(tbmonfee, "Image is missing.");
       return;
    }
    }
