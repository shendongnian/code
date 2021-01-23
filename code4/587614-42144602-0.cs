    public static Image AddUACShieldToImage(Image image)
        {
            var shield = SystemIcons.Shield.ToBitmap();
            shield.MakeTransparent();
    
            var g = Graphics.FromImage(image);
            g.CompositingMode = CompositingMode.SourceOver;
            g.DrawImage(shield, new Rectangle(image.Width / 2, image.Height / 2, image.Width / 2, image.Height / 2));
    
            return image;
        }
