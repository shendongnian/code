    private void WriteWatermarkText(Image image)
            {
                string watermark = config.Watermark.Text;
    
                if (string.IsNullOrEmpty(watermark))
                    return;
    
                // Pick an appropriate font size depending on image size
                int fontsize = (image.Width / watermark.Length);//get the font size with respect to length of the string;
    
                if (fontsize > 24)
                    fontsize = 18;
    
                // Set up the font
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                    Font font = new Font("Arial Black", fontsize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
    
                    // Determine size of watermark to write background
                    SizeF watermarkSize = graphics.MeasureString(watermark, font);
                    int xPosition = (image.Width / 2) - ((int)watermarkSize.Width / 2);
                    int yPosition = (image.Height / 2) - ((int)watermarkSize.Height / 2);
                   
                    // Write watermark
                    graphics.DrawString(
                    watermark,
                    font,
                    new SolidBrush(Color.FromArgb(config.Watermark.Opacity, Color.WhiteSmoke)),
                    xPosition,
                    yPosition
                    );
                    graphics.Dispose();
                }
            }
