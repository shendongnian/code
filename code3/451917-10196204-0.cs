    private byte[] GetPic(Image img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Bitmap bmp = new Bitmap(pbspic.Image);
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Position = 0;
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                return data;
            }
        }
