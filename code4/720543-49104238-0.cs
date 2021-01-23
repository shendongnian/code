    public float ResizePhoto(string filepath, string filename)
        {
            var path = Path.Combine(filepath, filename);
            var newPath = Path.Combine(filepath, "sml_" + filename);
            Image orgImage = Image.FromFile(path);
            float fixedHt = 180f;
            int destHeight, destWidth;
            float reqScale;
            if(orgImage.Height > fixedHt)
            {
                destHeight = (int)fixedHt;
                destWidth = (int)(fixedHt / orgImage.Height * orgImage.Width);
                reqScale = destWidth  / destHeight * 100;
            }
            else
            {
                destHeight = orgImage.Height;
                destWidth = orgImage.Width;
                reqScale = fixedHt / destHeight * 100;
            }
            Bitmap bmp = new Bitmap(destWidth, destHeight);
            bmp.SetResolution(orgImage.HorizontalResolution,orgImage.VerticalResolution);
            Graphics grPhoto = Graphics.FromImage(bmp);
            grPhoto.DrawImage(orgImage,
                new Rectangle(0, 0, destWidth,  destHeight),
                new Rectangle(0, 0, orgImage.Width, orgImage.Height),
                GraphicsUnit.Pixel);
            bmp.Save(newPath);
            return reqScale;
        }
