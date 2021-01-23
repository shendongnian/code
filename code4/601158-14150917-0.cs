    `public byte[] PictureBoxImageToBytes(PictureBox picBox) 
    {
         if ((picBox != null) && (picBox.Image != null))
        {
             Bitmap bmp = new Bitmap(picBox.Image);
             System.IO.MemoryStream ms = new System.IO.MemoryStream();
    
             bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
               
               byte[] buff = ms.ToArray();
    
             ms.Close();
             ms.Dispose();
             return buff;
        }
         else
        {
             return null;
        }
    }`
    
