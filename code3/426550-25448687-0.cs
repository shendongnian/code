        private void scaleFont(Label lab)
        {
            Image fakeImage = new Bitmap(1, 1); //As we cannot use CreateGraphics() in a class library, so the fake image is used to load the Graphics.
            Graphics graphics = Graphics.FromImage(fakeImage);
            SizeF extent = graphics.MeasureString(lab.Text, lab.Font);
            
            float hRatio = lab.Height / extent.Height;
            float wRatio = lab.Width / extent.Width;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;
            float newSize = lab.Font.Size * ratio;
            lab.Font = new Font(lab.Font.FontFamily, newSize, lab.Font.Style);
                        
        }
