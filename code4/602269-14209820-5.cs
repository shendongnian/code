        public Color this[int x, int y]
        {
            get
            {
                int index = y * (image.Width << 2) + x;
                return Color.FromArgb(rgbValues[index + 3], rgbValues[index + 2], rgbValues[index + 1], rgbValues[index]);
            }
            set
            {
                int index = y * (image.Width << 2) + x;
                rgbValues[index] = value.B;
                rgbValues[index + 1] = value.G;
                rgbValues[index + 2] = value.R;
                rgbValues[index + 3] = value.A;
            }
        }
