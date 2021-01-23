    string path = "C:\\test.jpg";
    using (Bitmap orignal = new Bitmap(path))
    {
            using (Bitmap newimage = new Bitmap((int)(orignal.Width * 0.5), (int)(orignal.Height * 0.5)))
            {
                    using (Graphics newgraphics = Graphics.FromImage(newimage))
                    {
                            newgraphics.DrawImage(orignal, 0, 0, new Rectangle(newimage.Width, newimage.Height, orignal.Width - newimage.Width, orignal.Height - newimage.Height), GraphicsUnit.Pixel);
                            newgraphics.Flush();
                    }
    
    
                    newimage.Save(new System.IO.FileInfo(path).DirectoryName + "out.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
    }
