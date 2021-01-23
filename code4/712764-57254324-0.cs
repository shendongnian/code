    public void ConvertToIco(Image img, string file, int size)
    {
        Icon icon;
        using (var msImg = new MemoryStream())
        using (var msIco = new MemoryStream())
        {
            img.Save(msImg, ImageFormat.Png);
            using (var bw = new BinaryWriter(msIco))
            {
                bw.Write((short)0);           //0-1 reserved
                bw.Write((short)1);           //2-3 image type, 1 = icon, 2 = cursor
                bw.Write((short)1);           //4-5 number of images
                bw.Write((byte)size);         //6 image width
                bw.Write((byte)size);         //7 image height
                bw.Write((byte)0);            //8 number of colors
                bw.Write((byte)0);            //9 reserved
                bw.Write((short)0);           //10-11 color planes
                bw.Write((short)32);          //12-13 bits per pixel
                bw.Write((int)msImg.Length);  //14-17 size of image data
                bw.Write(22);                 //18-21 offset of image data
                bw.Write(msImg.ToArray());    // write image data
                bw.Flush();
                bw.Seek(0, SeekOrigin.Begin);
                icon = new Icon(msIco);
            }
        }
        using (var fs = new FileStream(file, FileMode.Create, FileAccess.Write))
        {
            icon.Save(fs);
        }
    }
