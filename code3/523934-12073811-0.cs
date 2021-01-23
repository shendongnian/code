    public static void AddCenteredImage(ImageList list, Image image) {
        using (var bmp = new Bitmap(list.ImageSize.Width, list.ImageSize.Height))
        using (var gr = Graphics.FromImage(bmp)) {
            gr.Clear(Color.Transparent);   // Change background if necessary
            var size = image.Size;
            if (size.Width > list.ImageSize.Width || size.Height > list.ImageSize.Height) {
                // Image too large, rescale to fit the image list
                double wratio = list.ImageSize.Width / size.Width;
                double hratio = list.ImageSize.Height / size.Height;
                double ratio = Math.Min(wratio, hratio);
                size = new Size((int)(ratio * size.Width), (int)(ratio * size.Height));
            }
            var rc = new Rectangle(
                (list.ImageSize.Width - size.Width) / 2,
                (list.ImageSize.Height - size.Height) / 2,
                size.Width, size.Height);
            gr.DrawImage(image, rc);
            list.Images.Add(bmp);
        }
    }
