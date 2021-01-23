        Bitmap bmpCropped = new Bitmap(100, 100);
        Graphics g = Graphics.FromImage(bmpCropped);
        Rectangle rectDestination = new Rectangle(0, 0, bmpCropped.Width, bmpCropped.Height);
        Rectangle rectCropArea = new Rectangle(Int32.Parse(hfX.Value), Int32.Parse(hfY.Value), Int32.Parse(hfWidth.Value), Int32.Parse(hfHeight.Value));
    
    using (System.Drawing.Image img = System.Drawing.Image.FromFile(tempPath)) g.DrawImage(img, rectDestination, rectCropArea, GraphicsUnit.Pixel);
