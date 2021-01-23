        private byte[] GetImageBytes(string text)
        {
            using (var font = new Font("Tahoma", 20, FontStyle.Bold, GraphicsUnit.Pixel))
            using (var img = new Bitmap(1, 1))
            {
                int width;
                int height;
                using (var graphics = Graphics.FromImage(img))
                {
                    width = (int)graphics.MeasureString(text, font).Width;
                    height = (int)graphics.MeasureString(text, font).Height;
                }
                using (var realImg = new Bitmap(img, new Size(width, height)))
                {
                    using (var graphics = Graphics.FromImage(realImg))
                    {
                        graphics.Clear(Color.Transparent);
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        graphics.DrawString(text, font, new SolidBrush(Color.Black), 0, 0);
                    }
                    realImg.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    using (var stream = new System.IO.MemoryStream())
                    {
                        realImg.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        stream.Position = 0;
                        return stream.ToArray();
                    }
                }
            }
        }
