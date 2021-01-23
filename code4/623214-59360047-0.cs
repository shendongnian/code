            Font font = GetFont(fieldInfo, fontSize * 0.97f); // Chosen empirically
            using (var imageStream = new MemoryStream())
            {
                // Draw string as an image
                using (var bitmap = new Bitmap((int) fieldRect.Width, (int) (fieldRect.Height * 1.5f)))
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    graphics.DrawString(fieldValue, font, Brushes.Black, PointF.Empty);
                    bitmap.Save(imageStream, ImageFormat.Png);
                }
                // Draw image on PDF
                using (XImage xImage = XImage.FromStream(imageStream))
                {
                    double labelPositionX = fieldRect.X1 + 2;
                    double labelPositionY = fieldRect.Y2 - 2;
                    xGraphics.DrawImage(xImage, labelPositionX, page.Height - labelPositionY);
                }
            }
