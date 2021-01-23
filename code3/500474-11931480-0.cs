    public byte[] CropImage(int x, int y, int w, int h, byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                ms.Write(imageBytes, 0, imageBytes.Length);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms, true);
                Bitmap bmpCropped = new Bitmap(w, h);
                Graphics g = Graphics.FromImage(bmpCropped);
    
                Rectangle rectDestination = new Rectangle(0, 0, bmpCropped.Width, bmpCropped.Height);
                Rectangle rectCropArea = new Rectangle(x, y, w, h);
    
                g.DrawImage(img, rectDestination, rectCropArea, GraphicsUnit.Pixel);
                g.Dispose();
    
                MemoryStream stream = new MemoryStream();
                bmpCropped.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }
