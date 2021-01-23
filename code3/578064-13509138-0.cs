    private void btnPic_Click(object sender, EventArgs e)
	{
	    OpenFileDialog open = new OpenFileDialog();
	    open.Filter = "Images|*.bmp;*.jpg;*.gif|All files|*.*";
	    if (open.ShowDialog(this) == DialogResult.OK)
	    {
	         var image = Image.FromFile(open.FileName);
	         var newImage = ResizeCenterCropped(image, 300, 400);
	         newImage.Save(@open.FileName, ImageFormat.Png);
	    }
	}	
    
    public static Image ResizeCenterCropped(Image image, int width, int height)
    {
        var rect = CreateCroppedRectangle(image, width, height);
        rect.X = (image.Width / 2) - (rect.Width / 2);
        rect.Y = (image.Height / 2) - (rect.Height / 2);
        return Resize(image, new Rectangle(0, 0, width, height), rect);
    }
    public static Image Resize(Image image, Rectangle destRectange, Rectangle sourceRectangle)
    {
        var rezisedImage = new Bitmap(destRectange.Width, destRectange.Height)
        using (var g = Graphics.FromImage(rezisedImage))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawImage(image, destRectange, sourceRectangle, GraphicsUnit.Pixel);
            return rezisedImage;
        }
    }
    public static Rectangle CreateCroppedRectangle(Image image, int width, int height)
    {
        var size = new Size(width, height);
        var size2 = new Size(image.Width, image.Height);
        //The maximum scale width we could use
        float maxWidthScale = (float)size2.Width / (float)size.Width;
        //The maximum scale height we could use
        float maxHeightScale = (float)size2.Height / (float)size.Height;
        //Use the smaller of the 2 scales for the scaling
        float scale = Math.Min(maxHeightScale, maxWidthScale);
        size.Width = (int)(size.Width * scale);
        size.Height = (int)(size.Height * scale);
        return new Rectangle(new Point(), size);
    }
