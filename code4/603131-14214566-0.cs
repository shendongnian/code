    using (MemoryStream ms = new MemoryStream(ObjDt.ImgUpload))
    using (System.Drawing.Image image = System.Drawing.Image.FromStream(ms))              
    {
        image.Save(@"D:\Projects\WCF\WCF_ImageUpload\DamagedImages\" + strRandNo + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg); 
    }
