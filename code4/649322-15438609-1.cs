        class Program
        {
            static void Main(string[] args)
            {
                string filename = @"c:\testImage.png";
        
                // Load png from stream
                FileStream fs = new FileStream(filename, FileMode.Open);
                Image pngImage = Image.FromStream(fs);
                fs.Close();
        
                // super-hacky resize
                Graphics g = Graphics.FromImage(pngImage);
                pngImage = pngImage.GetThumbnailImage(image.Width, image.Height, null, IntPtr.Zero);
                g.DrawImage(pngImage, 0, 0, pngImage.Width + 4, pngImage.Height + 4); // <--- out of memory exception?!
        
                // save it out
                pngImage.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
        
